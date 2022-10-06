using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Persona
    {
        public int id { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string tercer_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string apellido_casada { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string direccion { get; set; }
        public int id_ubicacion { get; set; }
        public int id_tipopersona { get; set; }
        public int id_genero { get; set; }


        public Municipio Ubicacion { get; set; }
        
        public TipoPersona TipoPersona { get; set; }

        public Genero Genero { get; set; }


    }
}
