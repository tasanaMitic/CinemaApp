using CinemaApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
