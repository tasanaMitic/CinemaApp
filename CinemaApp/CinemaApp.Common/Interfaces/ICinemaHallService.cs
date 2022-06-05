using CinemaApp.Common.Dtos;

namespace CinemaApp.Common.Interfaces
{
    public interface ICinemaHallService
    {
        Guid AddCinemaHall(CinemaHallDto cinemaHallDto);
        bool DeleteCinemaHall(Guid id);
        IEnumerable<CinemaHallDtoId> GetAllCinemaHalls();
    }
}
