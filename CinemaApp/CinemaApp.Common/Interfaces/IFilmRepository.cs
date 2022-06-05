using CinemaApp.Models.Models;

namespace CinemaApp.Common.Interfaces
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
        IEnumerable<Film> Find(string criteria);
    }
}
