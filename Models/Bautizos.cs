using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Bautizos
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "No.Registro")]
        public int no_registro { get; set; }

        [Display(Name = "Nombres")]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Display(Name = "Genero")]
        public int GeneroId { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateTime fecha_nac { get; set; }

        [Display(Name = "Fecha del evento")]
        public DateTime fecha_evento { get; set; }


        [Display(Name = "Nombre del padre")]
        public string nombrePadre { get; set; }

        [Display(Name = "Nombre de la madre")]
        public string nombreMadre { get; set; }

        [Display(Name = "Nombre del padrino")]
        public string nombrePadrino { get; set; }


        [Display(Name = "Nombre de la madrina")]
        public string nombreMadrina { get; set; }

        [Display(Name = "Nota")]
        public string nota { get; set; }

        [Display(Name = "No. de libro")]
        public int no_libro { get; set; }


        [Display(Name = "No. de folio")]
        public int no_folio { get; set; }


        [Display(Name = "Fecha de Registro")]
        public DateTime fecha_registro { get; set; }


        [ForeignKey("GeneroId")]
        public virtual Generos genero { get; set; }
     
    }
}
