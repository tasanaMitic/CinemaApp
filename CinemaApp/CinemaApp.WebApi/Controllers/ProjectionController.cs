using CinemaApp.Common.Dtos;
using CinemaApp.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CinemaApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionController : ControllerBase
    {
        private readonly IProjectionService _projectionService;
        public ProjectionController(IProjectionService projectionService)
        {
            _projectionService = projectionService;
        }

        [HttpPost]
        public ActionResult<ProjectionDto> AddProjection(ProjectionDto projection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                Guid projectionId = _projectionService.AddProjection(projection);
                return CreatedAtAction("AddProjection", new { Id = projection }, projection);
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

        [HttpGet("{date}")]
        public ActionResult<IEnumerable<ProjectionDtoId>> GetProjections(string date)
        {
            return Ok(_projectionService.GetProjections(date));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProjection(Guid id)
        {
            return _projectionService.DeleteProjection(id) ? (IActionResult)NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProjection(Guid id, ProjectionDto projection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _projectionService.UpdateProjection(id, projection);
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
