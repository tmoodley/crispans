using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Services;

namespace Vue2Spa.Areas.Portal.Controllers.API
{
    public class User
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]User userParam)
        {
            var token = await _userService.AuthenticateAsync(userParam.Username, userParam.Password).ConfigureAwait(false);
        

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            var user = new User()
            {
                Username = userParam.Username,
                Token = token
            };  
            return Ok(user);
        } 
    }
}
