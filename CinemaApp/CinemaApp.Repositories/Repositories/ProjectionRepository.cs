using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using CinemaApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Repositories.Repositories
{
    public class ProjectionRepository : GenericRepository<Projection>, IProjectionRepository
    {
        public ProjectionRepository(CinemaContext context) : base(context) { }
        public IEnumerable<Projection> GetAllProjections()
        {
            return _context.Projections.Include("Film").Include("Cinemahall").ToList();
        }
    }
}
