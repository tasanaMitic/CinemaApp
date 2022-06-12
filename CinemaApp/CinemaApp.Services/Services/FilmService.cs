using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;

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
            Guid id = Guid.NewGuid();
            _unitOfWork.FilmRepository.Add(new Film
            {
                Id = id,
                Name = filmDto.Name,
                Director = filmDto.Director,
                Duration = filmDto.Duration,
                ReleaseYear = filmDto.ReleaseYear
            });
            foreach(var genre in filmDto.Genre)
            {
                _unitOfWork.FilmGenreRepository.Add(new FilmGenre { FilmId = id, GenreId = genre});
            }
            return id;
        }

        public bool DeleteFilm(Guid id)
        {
            var genres = _unitOfWork.FilmGenreRepository.Find(g => g.FilmId == id).ToList();
            foreach (var genre in genres)
            {
                _unitOfWork.FilmGenreRepository.Remove(genre.Id);
            }
            return _unitOfWork.FilmRepository.Remove(id);

        }

        public IEnumerable<FilmDtoId> GetAllFilms()
        {
            return _unitOfWork.FilmRepository.GetAll().Select(x => new FilmDtoId
            { 
                Name = x.Name, 
                Director = x.Director,
                Duration = x.Duration, 
                FilmId = x.Id, 
                ReleaseYear = x.ReleaseYear, 
                Genre = _unitOfWork.FilmGenreRepository.Find(g => g.FilmId == x.Id).ToList().Select(g => g.GenreId)
            });
        }

        //public IEnumerable<FilmDtoId> SearchFilms(string criteria)
        //{                                                                                                                                                                    
        //}
    }
}
