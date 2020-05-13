using HelpingHands.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Vue2Spa.Services
{
    public class InputModel
    { 
        public string Email { get; set; }
        public string Password { get; set; } 
    }
    public interface IUserService
    {
        Task<string> AuthenticateAsync(string username, string password); 
    }

    public class UserService : IUserService
    {    
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<UserService> _logger; 
        readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration1, SignInManager<ApplicationUser> signInManager, ILogger<UserService> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
            _configuration = configuration1;
        } 

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(username, password, true, lockoutOnFailure: true).ConfigureAwait(false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var _token = tokenHandler.WriteToken(token);
                  
                return _token;
            } 
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return null;
            }
            else
            {
                return null;
            } 
        } 
    }
}
