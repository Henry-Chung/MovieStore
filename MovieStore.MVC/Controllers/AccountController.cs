using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.Models.Request;
using MovieStore.Core.ServiceInterfaces;

namespace MovieStore.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            // Server side validation checks
            if (ModelState.IsValid)
            {
                // now call the service
                //var createdUser = 
                await _userService.RegisterUser(userRegisterRequestModel);
                return RedirectToAction("Login");
            }
            // we take this object from the View
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {
            // Http is stateless, each and every request is depent of each other
            // 10:00 AM u1 -> http://localhost/movies/index
            // 10:00 AM u2 -> http://localhost/movies/index
            // 10:00 AM u3 -> http://localhost/movies/index
            // 10:01 AM u1 -> http://localhost/movies/login, we can create an autheticate cookie
            // cookie is one way of storing information on browser, localstorage and sessionstorage
            // cookies, if there are any cookies present then those cookies will be automatically sent to the server
            // 10:00 AM u1 -> http://localhost/user/purchases  -> we nned to check if the cookie is expired or not and valid or not
            // we are expecting a page that shows movies bought by user1
            // cookies is one way og state management, client-side
            // 10:01 AM u2 -> http://localhost/movies/login
            if (ModelState.IsValid)
            {
                // call service layer to validate user
                var user = await _userService.ValidateUser(loginRequest.Email, loginRequest.Password);
                // we want to show First Name, Last Name on header (navigation)
                // create Claims based on your application needs

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,  user.Email),
                };

                // we need to create an Identity Object to hold those claims
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // finally we are going to create a cookie that will be attached to the Http Response
                // HttpContext is probably most imporant class in ASP.NET, that holds all the information regarding that Http Request/Response
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // manually creating cookie
                //HttpContext.Response.Cookies.Append("userLanguage", "English");
                // Once ASP.NET Craetes AUthntication Cookies, it will check for that cookie in the HttpRequest and see if the cookie is not expired
                // and it will decrypt the information present in the cookie to check whether User is Authenticated and will also get claims from the cookies
                return LocalRedirect("/");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return LocalRedirect("~/");
        }
    }
}
