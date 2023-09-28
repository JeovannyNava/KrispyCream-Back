using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sln2_Back.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Clave { get; set; }
        
    }
}
