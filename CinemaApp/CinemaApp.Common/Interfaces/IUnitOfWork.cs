using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICinemaHallRepository CinemaHallRepository { get; }
        IFilmRepository FilmRepository { get; }
        IProjectionRepository ProjectionRepository { get; }
        ITicketRepository TicketRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
