using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Municipio
    {
        public int id { get; set; }
        public int id_departamento { get; set; }
        public string municipio { get; set; }
        public Departamento Departamento { get; set; }

    }
}
