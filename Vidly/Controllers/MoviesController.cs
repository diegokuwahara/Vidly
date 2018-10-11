using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;
using Vidly.DatabaseResource;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlYDbContext _context;

        public MoviesController()
        {
            _context = new VidlYDbContext();
        }

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
            var movies = _context.Movies.Include(m => m.Genre).ToList();
           
            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return View();
        }

        [Route("Movies/Details/{id:range(1,2)}")]
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}