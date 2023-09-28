using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sln2_Back.Models;
using Sln2_Back.Service;
using Sln2_Back.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln2_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PedidoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Authorize]
        public ResponseAPI Post(Pedido pedido)
            {
            var service = new PedidoService(_configuration);
            var response = service.CrearPedido(pedido);
            return response;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var service = new PedidoService(_configuration);
            var pedidos = service.GetPedidos();
            return Ok(pedidos);
        }

    }
}
