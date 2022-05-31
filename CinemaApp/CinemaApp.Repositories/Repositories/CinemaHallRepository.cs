using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using CinemaApp.Repositories.Context;

namespace CinemaApp.Repositories.Repositories
{
    public class CinemaHallRepository : GenericRepository<Cinemahall>, ICinemaHallRepository
    {
        public CinemaHallRepository(CinemaContext context) : base(context) { }
    }
}
