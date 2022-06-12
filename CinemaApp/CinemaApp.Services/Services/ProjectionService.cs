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
                                                                  Date = projectionDto.Date.Date,
                                                                  Time = projectionDto.Time,  
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
            return _unitOfWork.ProjectionRepository.GetAllProjections().Select(x => new ProjectionDtoId()
            {
                ProjectionId = x.Id,
                Date = x.Date,
                Time = x.Time,
                SoldOut = x.SoldOut,
                FilmId = x.Film.Id, //TO DO     - da li vracati id ili ceo objekat
                CinemaHallId = x.Cinemahall.Id
            }).Where(x => x.Date == Convert.ToDateTime(date));
        }

        public void UpdateProjection(Guid id, ProjectionDto projectionDto)
        {
            var film = _unitOfWork.FilmRepository.GetById(projectionDto.FilmId);
            var cinemaHall = _unitOfWork.CinemaHallRepository.GetById(projectionDto.CinemaHallId);
            _unitOfWork.ProjectionRepository.Update(new Projection{ Id = id,
                                                                        Date = projectionDto.Date,
                                                                        Time = projectionDto.Time,  
                                                                        SoldOut = projectionDto.SoldOut,
                                                                        Film = film,
                                                                        Cinemahall = cinemaHall});
        }
    }
}
