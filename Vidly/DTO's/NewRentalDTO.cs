using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO_s
{
    public class NewRentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}