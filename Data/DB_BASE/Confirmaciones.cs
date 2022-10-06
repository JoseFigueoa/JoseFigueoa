using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class Confirmaciones
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public int IdPersona { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? FechaEvento { get; set; }

        [Display(Name = "Padrino")]
        public int? IdPadrino { get; set; }

        [Display(Name = "MAdrina")]
        public int? IdMadrina { get; set; }

        [Display(Name = "Libro")]
        public int? Libro { get; set; }

        [Display(Name = "Folio")]
        public int? Folio { get; set; }

        [Display(Name = "Nota")]
        public string Nota { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime? FechaRegistro { get; set; }


        [Display(Name = "Registro")]
        public string NoRegistro { get; set; }


        [Display(Name = "Madrina")]

        public virtual Personas IdMadrinaNavigation { get; set; }

        [Display(Name = "Padrino")]
        public virtual Personas IdPadrinoNavigation { get; set; }

        [Display(Name = "Nombre")]
        public virtual Personas IdPersonaNavigation { get; set; }
    }
}
