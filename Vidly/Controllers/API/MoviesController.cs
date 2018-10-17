using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.DatabaseResource;
using Vidly.DTO_s;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<MovieDTO> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
               .Include(c => c.Genre)
               .Where(m => m.Available > 0);
                
            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

             var movies = moviesQuery
                .ToList()
                .Select(Mapper.Map < Movie, MovieDTO>);

            return movies;
        }

        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies
                .Include(c => c.Genre)
                .SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        [HttpPut]
        public void UpdateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = _context.Movies.Single(c => c.Id == movieDTO.Id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDTO, movieInDB);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var movieInDb = _context.Movies.Single(c => c.Id == Id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
