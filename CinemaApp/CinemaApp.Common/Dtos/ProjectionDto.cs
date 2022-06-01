
namespace CinemaApp.Common.Dtos
{
    public class ProjectionDto
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public bool SoldOut { get; set; }
        public Guid FilmId { get; set; }
        public Guid CinemaHallId { get; set; }
    }
}
