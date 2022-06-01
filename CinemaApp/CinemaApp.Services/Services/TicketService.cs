using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;

namespace CinemaApp.Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Guid BuyTicket(TicketDto ticketDto)
        {
            //TODO
            Guid id = new Guid();
            User user = _unitOfWork.UserRepository.GetById(new Guid()); // username
            Projection projection = _unitOfWork.ProjectionRepository.GetById(ticketDto.ProjectionId);
            _unitOfWork.TicketRepository.Add(new Ticket { Id = id,
                                                          Number = ticketDto.Number, 
                                                          Price = ticketDto.Price, 
                                                          Sold = true, 
                                                          User = user, 
                                                          Projection = projection });
            return id;
        }

        public bool DeleteTicket(Guid id)
        {
            return _unitOfWork.TicketRepository.Remove(id);
        }

        public IEnumerable<TicketDtoId> GetTickets(string projection)
        {
            return _unitOfWork.TicketRepository.Find(projection).Select(x => new TicketDtoId() { Number = x.Number, Price = x.Price, Sold = x.Sold, TicketId = x.Id, ProjectionId = x.Projection.Id, Username = x.User.Username });
        }
    }
}
