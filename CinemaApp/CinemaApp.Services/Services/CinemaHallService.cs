using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using CinemaApp.Models.Models;

namespace CinemaApp.Services.Services
{
    public class CinemaHallService : ICinemaHallService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CinemaHallService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Guid AddCinemaHall(CinemaHallDto cinemaHallDto)
        {
            Guid id = new Guid();
            _unitOfWork.CinemaHallRepository.Add(new Cinemahall {Id = id, 
                                                                Name =  cinemaHallDto.Name, 
                                                                NmbrOfSeats = cinemaHallDto.NumberOfSeats });
            return id;
        }

        public bool DeleteCinemaHall(Guid id)
        {
            return _unitOfWork.CinemaHallRepository.Remove(id);
        }

        public IEnumerable<CinemaHallDtoId> GetAllCinemaHalls()
        {
            return _unitOfWork.CinemaHallRepository.GetAll().Select(x => new CinemaHallDtoId() { Name = x.Name, NumberOfSeats = x.NmbrOfSeats, CinemaHallId = x.Id });
        }
    }
}
