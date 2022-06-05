using CinemaApp.Common.Dtos;

namespace CinemaApp.Common.Interfaces
{
    public interface IFilmService
    {
        Guid AddFilm(FilmDto filmDto);
        IEnumerable<FilmDtoId> GetAllFilms();
        IEnumerable<FilmDtoId> SearchFilms(string criteria);
        bool DeleteFilm(Guid id);
    }
}
