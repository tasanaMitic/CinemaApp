using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Required]
        public IEnumerable<FilmGenre> Genre { get; set; }
    }
}
