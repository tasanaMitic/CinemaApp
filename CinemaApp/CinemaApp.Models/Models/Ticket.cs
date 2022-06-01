using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models.Models
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public bool Sold { get; set; }
        [Required]
        public User User { get; set;  }
        [Required]
        public Projection Projection { get; set; }
    }
}
