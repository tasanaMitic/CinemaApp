namespace CinemaApp.Common.Dtos
{
    public class TicketDto
    {
        public int Number { get; set; }
        public int Price { get; set; }
        public bool Sold { get; set; }
        public string Username { get; set; }
        public Guid ProjectionId { get; set; }
    }
}
