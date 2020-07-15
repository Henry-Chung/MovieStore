using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IActionResult Index()
        {


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
            return View();
        }

        //public string Index()
        //{
        //    return "ABC";
        //}

        public interface xyx
        {
            int Add(int x, int y);
        }

    }
}
