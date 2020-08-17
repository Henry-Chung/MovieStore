using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Core.Models.Request;
using MovieStore.Core.ServiceInterfaces;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet]
        //[Route("{id:int}", Name = "GetUser")]
        //public async Task<ActionResult> GetUserByIdAsync(int id)
        //{
        //    var user = await _userService.GetUserDetails(id);
        //    return Ok(user);
        //}


        [HttpPost]
        [Route("register")]
        // htpp://localhost/api/account/register -- Http Post
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestModel model)
        {
            // Model Binding
            //when posting join data, make sure your join keys are same as C# model properties
            //{
            //    "firstName" : "Henry",
            //    "lastName": "Chung",
            //    "email" : "henry@yahoo.com.tw",
            //    "Password":"test123pP@"
            //}


            var user = await _userService.RegisterUser(model);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequestModel loginRequest)
        {
            var user = await _userService.ValidateUser(loginRequest.Email, loginRequest.Password);
            if (user == null) return Unauthorized();

            return Ok(user);
        }

    }
}
