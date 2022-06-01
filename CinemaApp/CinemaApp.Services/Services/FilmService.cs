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
    public class FilmService : IFilmService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Guid AddFilm(FilmDto filmDto)
        {
            Guid id = new Guid();
            _unitOfWork.FilmRepository.Add(new Film { Id = id,
                                                      Name = filmDto.Name,
                                                      Director = filmDto.Director,
                                                      Genre = (IEnumerable<FilmGenre>)filmDto.Genre, //TODO
                                                      Duration = filmDto.Duration,
                                                      ReleaseYear = filmDto.ReleaseYear });
            return id;
        }

        public bool DeleteFilm(Guid id)
        {
            return _unitOfWork.FilmRepository.Remove(id);
        }

        public IEnumerable<FilmDtoId> GetAllFilms()
        {
            return _unitOfWork.FilmRepository.GetAll().Select(x => new FilmDtoId() { Name = x.Name, Director = x.Director, Duration = x.Duration, FilmId = x.Id, ReleaseYear = x.ReleaseYear, Genre = x.Genre.Cast<string>().ToList() });
        }

        public IEnumerable<FilmDtoId> SearchFilms(string criteria)
        {
            //TODO
            return _unitOfWork.FilmRepository.Find(criteria: criteria).Select(x => new FilmDtoId() { Name = x.Name, Director = x.Director, Duration = x.Duration, FilmId = x.Id, ReleaseYear = x.ReleaseYear, Genre = x.Genre.Cast<string>().ToList() });
        }
    }
}
