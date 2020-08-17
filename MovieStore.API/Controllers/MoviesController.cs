using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.ServiceInterfaces;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // we want to construct a URL for showing top 25 revenue movies
        // [Route("api/[controller]")]
        // http:localhost/api/movies/toprevenue -- GET
        // SEO , RESTFul URL's, -- should be human readable
        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop25HighestRevenueMovies();
            // in MVC we return Views
            // return data along with HTTP Status CODE
            //  OK -200
            if (!movies.Any())
            {
                return NotFound("No Movies Found!");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTop25RatedMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMovieByGenreId(genreId);
            return Ok(movies);
        }

        [HttpGet]
        [Route("user/{userId:int}")]
        public async Task<IActionResult> GetMovieByUser(int userId)
        {
            var movies = await _movieService.GetMovieByUserId(userId);
            return Ok(movies);
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetAllMovies([FromQuery] int pageSize = 30, [FromQuery] int page = 1,
        //    string title = "")
        //{
        //    var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
        //    return Ok(movies);
        //}





        //[HttpGet]
        //[Route("toprevenue")]
        //public async Task<IActionResult> GetTopRevenueMovies()
        //{
        //    var movies = await _movieService.GetHighestGrossingMovies();
        //    return Ok(movies);
        //}



        //[HttpGet]
        //[Route("{id}/reviews")]
        //public async Task<IActionResult> GetMovieReviews(int id)
        //{
        //    var reviews = await _movieService.GetReviewsForMovie(id);
        //    return Ok(reviews);
        //}
    }
}
