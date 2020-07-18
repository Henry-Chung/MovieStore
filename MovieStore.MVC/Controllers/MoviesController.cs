using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.ServiceInterfaces;
using MovieStore.Infrastructure.Services;
using MovieStore.MVC.Models;
namespace MovieStore.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        //  GET localhost/Movies/index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // call our Movie Service ,method, highest grossing method
            //var movies = await _movieService.GetTop25HighestRevenueMovies();
            var movies = await _movieService.GetTop25RatedMovies();

            return View(movies);
        }
        // IOC, ASP.NET Core has built-in IOC/DI
        // In .NET Framework we need to to rely on third-party IOC to do Dependency Injection, Autofac, Ninject

    }
}
