using CinemaApp.Common.Dtos;

namespace CinemaApp.Common.Interfaces
{
    public interface ITicketService
    {
        Guid BuyTicket(TicketDto ticketDtp);
        IEnumerable<TicketDtoId> GetTickets(string projection); //or username //TODO
        bool DeleteTicket(Guid id);
    }
}
