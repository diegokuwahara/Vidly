using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        [Required]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Stock must be between 1 and 20")]
        [Range(1, 20)]
        public int? Stock { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required")]
        public int? GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }
    }
}