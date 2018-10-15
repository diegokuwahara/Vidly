using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO_s
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Stock must be between 1 and 20")]
        [Range(1, 20)]
        public int Stock { get; set; }

        public virtual GenreDTO Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required")]
        public int GenreId { get; set; }
    }
}