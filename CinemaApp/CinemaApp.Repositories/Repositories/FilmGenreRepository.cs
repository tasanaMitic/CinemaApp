using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using CinemaApp.Repositories.Context;

namespace CinemaApp.Repositories.Repositories
{
    public class FilmGenreRepository : GenericRepository<FilmGenre>, IFilmGenreRepository
    {
        public FilmGenreRepository(CinemaContext context) : base(context) { }
    }
}
