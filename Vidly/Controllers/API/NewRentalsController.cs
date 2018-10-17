using System;
using System.Linq;
using System.Web.Http;
using Vidly.DatabaseResource;
using Vidly.DTO_s;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private VidlyDbContext _context;

        public NewRentalsController()
        {
            _context = new VidlyDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        // GET: NewRentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.Available == 0)
                    return BadRequest("Movie not available");
                movie.Available--;

                var newDbRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                
                _context.Rentals.Add(newDbRental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}