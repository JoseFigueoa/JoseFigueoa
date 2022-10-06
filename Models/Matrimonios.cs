using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Matrimonios
    {

        [Key]
        public int id { get; set; }
        public int no_registro { get; set; }
        public string nombreEsposo { get; set; }
        public string nombreEsposa { get; set; }
        public DateTime fecha_evento { get; set; }
        public int no_libro { get; set; }
        public int no_folio { get; set; }
        public DateTime fecha_registro { get; set; }
        public string nota { get; set; }
    }
}
