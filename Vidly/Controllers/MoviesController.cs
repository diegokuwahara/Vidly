using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "xerek" };
            var customers = new List<Customer>
            {
                new Customer {
                                Name = "Customer 1",
                                Id = 1
                             },
                new Customer {
                                Name = "Customer 2",
                                Id = 2
                             }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            var viewResult = new ViewResult();
            return View(viewModel);
        }

        [Route("Movies")]
        public ActionResult Movies()
        {
            var movies = GetMovies();
           
            return View(movies);
        }

        [Route("Movies/Details/{id:range(1,2)}")]
        public ActionResult Details(int Id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
    }
}