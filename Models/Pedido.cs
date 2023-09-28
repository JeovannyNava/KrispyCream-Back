using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sln2_Back.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdDona { get; set; }
        public int Cantidad { get; set; }
    }
}
