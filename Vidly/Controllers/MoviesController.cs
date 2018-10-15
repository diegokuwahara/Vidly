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
        private VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
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
            return View("Form", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var genres = _context.Genres.ToList();
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres
            };
            return View("Form", viewModel);
        }

        [HttpPost]
<<<<<<< HEAD
        public ActionResult Create(MovieFormViewModel viewModel)
        {
            _context.Movies.Add(movie);
=======
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("Form", viewModel);
                
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieAtt = _context.Movies.Single(m => m.Id == movie.Id);
                movieAtt.Name = movie.Name;
                movieAtt.GenreId = movie.GenreId;
                movieAtt.ReleaseDate = movie.ReleaseDate;
                movieAtt.Stock = movie.Stock;
            }
            
>>>>>>> 9a0c628dead1d34804023ca7d9d6812316811850
            _context.SaveChanges();

            return RedirectToAction("Movies", "Movies");
        }
        
        public ActionResult Delete(int Id)
        {
            var movieDel = _context.Movies.Single(m => m.Id == Id);
            _context.Movies.Remove(movieDel);
            _context.SaveChanges();

            return RedirectToAction("Movies", "Movies");
        }

        [Route("Movies/Details/{id}")]
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