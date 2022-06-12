using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Services
{
    public class ProjectionService : IProjectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Guid AddProjection(ProjectionDto projectionDto)
        {
            Guid id = Guid.NewGuid();
            Film film = _unitOfWork.FilmRepository.GetById(projectionDto.FilmId);
            Cinemahall cinemaHall = _unitOfWork.CinemaHallRepository.GetById(projectionDto.CinemaHallId);
            _unitOfWork.ProjectionRepository.Add(new Projection { Id = id, 
                                                                  Date = projectionDto.Date,
                                                                  //Time = projectionDto.Time,  //TODO
                                                                  SoldOut = projectionDto.SoldOut,
                                                                  Film = film,
                                                                  Cinemahall = cinemaHall });
            return id;
        }

        public bool DeleteProjection(Guid id)
        {
            return _unitOfWork.ProjectionRepository.Remove(id);
        }

        public IEnumerable<ProjectionDtoId> GetProjections(string date)
        {
            return _unitOfWork.ProjectionRepository.GetAll().Select(x => new ProjectionDtoId()
            {
                ProjectionId = x.Id,
                Date = x.Date,
                //Time = x.Time, //TODO
                SoldOut = x.SoldOut,
                FilmId = x.Film.Id,
                CinemaHallId = x.Cinemahall.Id
            });
        }

        public void UpdateProjection(Guid id, ProjectionDto projectionDto)
        {
            //TODO
            Film film = _unitOfWork.FilmRepository.GetById(projectionDto.FilmId);
            Cinemahall cinemaHall = _unitOfWork.CinemaHallRepository.GetById(projectionDto.CinemaHallId);
            _unitOfWork.ProjectionRepository.Update(id, new Projection{ Id = id,
                                                                        Date = projectionDto.Date,
                                                                        //Time = projectionDto.Time,  //TODO
                                                                        SoldOut = projectionDto.SoldOut,
                                                                        Film = film,
                                                                        Cinemahall = cinemaHall});
        }
    }
}
