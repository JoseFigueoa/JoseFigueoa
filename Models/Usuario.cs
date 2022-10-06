using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }        
    }
}
