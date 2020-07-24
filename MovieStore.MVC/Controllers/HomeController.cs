using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MovieStore.Core.Entities;
using MovieStore.Core.ServiceInterfaces;
using MovieStore.Infrastructure.Services;
using MovieStore.MVC.Models;

namespace MovieStore.MVC.Controllers
{
    // Any C# class can become a MVC Controller if it inherits from Controeller base class

    // Get http://localhost:2323/Home/index/2
    // http://localhost:2323/
    // http://localhost:2323/Home/index


    // Routing -- Patern matching technique
    // HomeController
    // Index -- Action method
    public class HomeController : Controller
    {
        // Action method
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            // we need or Movie Card we are going to use that one in lots of places...
            // 1. Home page -- show top revenue movies --> Movie Card
            // 2. Genres/show Movies belonginf to that genre --> Movie Card
            // 3. Top Rated Movies --> Top Movies as a card
            // We have to create this Movie Card in such a way that it can be reused in lots of places
            // Partial Views will help us in creating reusable Views across the application
            // Partial views are views inside another view

            // 0 and null
            // return a instance of a class that implements that Interface
            // By default MVC will look for same View name as Action method name
            // it will look inside Views folder --> Home (same name as controller) -->  Index.cschtml

            // 1. Program.cs -- > Main method
            // 2. StarUp Calss
            // 3. ConfigureServices
            // 4. Configure
            // 5. HomeController
            // 6. Action method
            // 7. return a View

            // In ASP.NET Core Middleware...... a piece of software logic that will be executed
            // Train--- DC to Boston

            // DC ===20, multiple stops...Phill, NJ, NY --Boston
            // request --> M1 -- some process --> next M2 --> next M3 ....Mn --> Response

            var movies = await _movieService.GetTop25HighestRevenueMovies();
            
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> UserMovieList(int uid)
        {
            var movies = await _movieService.GetMovieByUserId(uid);
            return View("Index", movies);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

    }
}
