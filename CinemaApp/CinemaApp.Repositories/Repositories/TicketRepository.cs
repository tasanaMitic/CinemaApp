using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;
using CinemaApp.Repositories.Context;

namespace CinemaApp.Repositories.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(CinemaContext context) : base(context) { }

        //TODO
        public IEnumerable<Ticket> Find(string projectionId)
        {
            throw new NotImplementedException();
        }
    }
}
