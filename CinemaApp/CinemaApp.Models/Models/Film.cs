using System.ComponentModel.DataAnnotations;
namespace CinemaApp.Models.Models
{
    public class Film
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
    }
}
