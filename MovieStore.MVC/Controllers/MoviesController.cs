using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.MVC.Models;
namespace MovieStore.MVC.Controllers
{
    public class MoviesController : Controller
    {
        // get localhost/Movies/index
        [HttpGet]
        public IActionResult Index()
        {
            //var movies = new List<Movie>
            //{
            //    new Movie {Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
            //    new Movie {Id = 2, Title = "Avatar", Budget = 1200000},
            //    new Movie {Id = 3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
            //    new Movie {Id = 4, Title = "Titanic", Budget = 1200000},
            //    new Movie {Id = 5, Title = "Inception", Budget = 1200000},
            //    new Movie {Id = 6, Title = "Avengers: Age of Ultron", Budget = 1200000},
            //    new Movie {Id = 7, Title = "Interstellar", Budget = 1200000},
            //    new Movie {Id = 8, Title = "Fight Club", Budget = 1200000},
            //};

            

            // compile time checks vs run-time checks

            var list = new List<int>();

            // we need to pass data from controller action method to the view
            // usually is preffered to send a strongly typed Model or object

            // 3 ways to send data from Controller to View
            // 1. Strongly-typed models (preferred way)
            // 2. ViewBag --dynamic
            // 3. ViewData - key/value

            //ViewBag.MoviesCount = movies.Count;
            ViewData["myname"] = "John Doe";
            
            //return View(movies);
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, decimal budget, string TITLE)
        {
            // Post // http:localhost/Movies/Create

            // Model binding they are case in-sensitive
            // look at in0coming request and maps the input elements name/value with the parameter names of the action method
            // then the parameter will have the value automatically
            //it will also does casting/converting
            // we need to get the data from the view and save it in database
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            // http:localhost/Movies/Create
            // we need to have this method so that we can show the empty page for user to enter Movie information that needs to be created
            return View();
        }

    }
}
