using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using CinemaApp.Repositories.Context;

namespace CinemaApp.Repositories.Repositories
{
    public class ProjectionRepository : GenericRepository<Projection>, IProjectionRepository
    {
        public ProjectionRepository(CinemaContext context) : base(context) { }
    }
}
