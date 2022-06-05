using CinemaApp.Models.Models;

namespace CinemaApp.Common.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        IEnumerable<Ticket> Find(string projectionId);
    }
}
