using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CinemaApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserDto> AddUser(UserDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                string username = _userService.AddUser(user);
                return CreatedAtAction("AddUser", new { Id = username }, user);
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
        public ActionResult<IEnumerable<UserDtoId>> GetAllUsers(string userRole)
        {
            return Ok(_userService.GetAllUsers(userRole));
        }

        [HttpGet("{username}")]
        public ActionResult<IEnumerable<UserDtoId>> SearchUsers(string username, string userRole)
        {
            return Ok(_userService.SearchUsers(username, userRole));
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            return _userService.DeleteUser(username) ? (IActionResult)NoContent() : NotFound();
        }

        [HttpPut("{username}")]
        public IActionResult UpdateUser(string username, UserDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _userService.UpdateUser(username, user);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
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
    }
}
