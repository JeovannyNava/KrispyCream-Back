using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sln2_Back.Service;
using Sln2_Back.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sln2_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Post(LoginVM login)
        {
            var serviceLogin = new ServiceLogin(_configuration);

            if (serviceLogin.IsValidUser(login.Usuario, login.Clave))
            {
                var token = serviceLogin.GenerateJwtToken(login.Usuario);
                return Ok(new { token });
            }

            return Unauthorized();
        }



    }
}
