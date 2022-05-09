using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    /// <summary>
    /// Movie Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly ILogger<MovieController> _logger;

        /// <summary>
        /// Movie Controller Constructor
        /// </summary>
        /// <param name="logger"></param>
        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Get list of movies that match the name searched
        /// </summary>
        /// <param name="name">Name of the movie to retrieve</param>
        /// <returns>List of movies</returns>
        [HttpGet]
        public IActionResult Get(string name)
        {

            var movies = Mock.GetMovies(name);

            if (movies != null && movies.Count > 0)
            {
                return Ok(movies);
            }
            return NotFound();


        }

        /// <summary>
        /// Add new movie
        /// </summary>
        /// <param name="movie">Movie object to add</param>
        /// <returns>Movie added</returns>
        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            if(movie == null || movie.Id == 0 || movie.Name.Length == 0 || movie.ReleaseDate == DateTime.MinValue)
            {
                return BadRequest();
            }

            var movies = Mock.GetMovies(null);
            movies.Add(movie);

            var result = movies.Where(m => m.Id == movie.Id).FirstOrDefault();

            if (result != null && result.Id > 0)
            {
                return Ok(result);
            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Modifies Movie information
        /// </summary>
        /// <param name="movie">Movie information to edit</param>
        /// <returns>Modified Movie</returns>
        [HttpPut]
        public IActionResult Put(Movie movie)
        {
            if (movie == null || movie.Id == 0 || movie.Name.Length == 0 || movie.ReleaseDate == DateTime.MinValue)
            {
                return BadRequest();
            }

            var movies = Mock.GetMovies(null);

            var modifiedMovie = movies.Where(m => m.Id == movie.Id).First();

            if (modifiedMovie != null)
            {
                modifiedMovie = movie;
                return Ok(modifiedMovie);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

      


    
    }
}
