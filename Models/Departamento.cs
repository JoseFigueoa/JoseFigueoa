using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Departamento
    {
        public int id { get; set; }
        public int id_pais { get; set; }
        public string departamento { get; set; }
        public Pais Pais { get; set; }
    }
}
