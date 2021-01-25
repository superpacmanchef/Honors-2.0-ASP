using Honors_2._0.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Honors_2._0.Domain.Models;
using Microsoft.AspNetCore.Identity;


namespace Honors_2._0.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService  )
        {
            _userService = userService;

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<bool> Login([FromForm]string Email , [FromForm]string Password) 
        {

            Users user  =  await _userService.Login(Email, Password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserID", user.UserId);
                return true;
            }
            else
            {
                return false;
            }

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<int> Register([FromForm] string Email , [FromForm] string Password , [FromForm] string FirstName , [FromForm] string Surname)
        {
            return await _userService.Register(Email, Password, FirstName, Surname);
            
        }

        
    }
}
