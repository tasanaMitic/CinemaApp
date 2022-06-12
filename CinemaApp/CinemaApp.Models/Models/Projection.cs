using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Models.Models
{
    public class Projection
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public bool SoldOut { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual Film Film { get; set; }
        [Required]
        public virtual Cinemahall Cinemahall { get; set; }
    }
}
