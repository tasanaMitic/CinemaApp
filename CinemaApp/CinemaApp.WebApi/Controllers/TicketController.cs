using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CinemaApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public ActionResult<TicketDto> BuyTicket(TicketDto ticket)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                Guid ticketId = _ticketService.BuyTicket(ticket);
                return CreatedAtAction("BuyTicket", new { Id = ticketId }, ticket);
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
        public ActionResult<IEnumerable<TicketDtoId>> GetTickets(string projection)
        {
            return Ok(_ticketService.GetTickets(projection));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(Guid id)
        {
            return _ticketService.DeleteTicket(id) ? (IActionResult)NoContent() : NotFound();
        }
    }
}
