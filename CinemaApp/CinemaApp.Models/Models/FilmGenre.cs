using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models.Models
{
    public class FilmGenre
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string GenreName { get; set; }
    }
}
