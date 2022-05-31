using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using CinemaApp.Repositories.Context;

namespace CinemaApp.Repositories.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(CinemaContext context) : base(context) { }

        public IEnumerable<Film> Find(string criteria)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
