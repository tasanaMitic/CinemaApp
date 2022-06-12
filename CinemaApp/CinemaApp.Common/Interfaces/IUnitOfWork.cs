namespace CinemaApp.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICinemaHallRepository CinemaHallRepository { get; }
        IFilmRepository FilmRepository { get; }
        IProjectionRepository ProjectionRepository { get; }
        ITicketRepository TicketRepository { get; }
        IUserRepository UserRepository { get; }
        IFilmGenreRepository FilmGenreRepository { get; }
    }
}
