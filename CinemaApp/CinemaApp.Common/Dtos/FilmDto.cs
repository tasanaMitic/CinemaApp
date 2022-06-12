namespace CinemaApp.Common.Dtos
{
    public class FilmDto
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public IEnumerable<int> Genre { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
    }
}
