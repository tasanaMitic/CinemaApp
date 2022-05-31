using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models.Models
{
    public class Cinemahall
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NmbrOfSeats { get; set; }
    }
}
