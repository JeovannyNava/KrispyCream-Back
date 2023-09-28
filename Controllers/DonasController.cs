using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sln2_Back.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln2_Back.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DonasController : Controller
    {
        private readonly IConfiguration _configuration;
        public DonasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetDonas()
        {
            var service = new DonasService(_configuration);
            var donas = service.GetDonas();
            return Ok(donas);
        }
    }
}
