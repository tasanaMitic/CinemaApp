
using CinemaApp.Common.Dtos;

namespace CinemaApp.Common.Interfaces
{
    public interface IProjectionService
    {
        Guid AddProjection(ProjectionDto projectionDto);
        IEnumerable<ProjectionDtoId> GetProjections(string date);
        bool DeleteProjection(Guid id);
        void UpdateProjection(Guid id, ProjectionDto projectionDto);
    }
}
