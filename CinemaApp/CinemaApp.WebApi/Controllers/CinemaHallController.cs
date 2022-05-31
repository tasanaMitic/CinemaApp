using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CinemaApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaHallController : ControllerBase
    {
        private readonly ICinemaHallService _cinemaHallService;
        public CinemaHallController(ICinemaHallService cinemaHallService)
        {
            _cinemaHallService = cinemaHallService;
        }

        [HttpPost]
        public ActionResult<CinemaHallDto> AddCinemaHall(CinemaHallDto cinemaHall)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                //Guid cinemaHallId = _cinemaHallService.AddCinemaHall(cinemaHall);
                //return CreatedAtAction("AddCinemaHall", new { Id = cinemaHallId }, cinemaHall);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest();
            }
            catch (DuplicateNameException e)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public ActionResult<IEnumerable<CinemaHallDtoId>> GetAllCinemaHalls()
        {
            //return Ok(_cinemaHallService.GetAllCinemaHalls());
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCinemaHall(int id)
        {
            return Ok();
            //return _cinemaHallService.DeleteCinemaHall(id) ? (IActionResult)NoContent() : NotFound();
        }
    }
}
