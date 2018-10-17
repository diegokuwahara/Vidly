using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateRented { get; set; }
        
        public DateTime? DateReturned { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        [Required]
        public virtual Movie Movie { get; set; }
    }
}