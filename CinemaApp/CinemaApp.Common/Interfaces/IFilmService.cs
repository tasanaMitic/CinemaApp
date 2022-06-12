using CinemaApp.Common.Dtos;

namespace CinemaApp.Common.Interfaces
{
    public interface IFilmService
    {
        Guid AddFilm(FilmDto filmDto);
        IEnumerable<FilmDtoId> GetAllFilms();
        bool DeleteFilm(Guid id);
    }
}
