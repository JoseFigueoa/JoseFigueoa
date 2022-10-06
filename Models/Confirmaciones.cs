using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Confirmaciones
    {

        [Key]
        public int id { get; set; }
        public int no_registro { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int generoId { get; set; }
        public DateTime fecha_evento { get; set; }
        public string nombrePadrino { get; set; }
        public string nombreMadrina { get; set; }
        public int no_libro { get; set; }
        public int no_folio { get; set; }
        public string nota { get; set; }
        public DateTime fecha_registro { get; set; }



        [ForeignKey("generoId")]
        public virtual Generos generos { get; set; }
    }
}
