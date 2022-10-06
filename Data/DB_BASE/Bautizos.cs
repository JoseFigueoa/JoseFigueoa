using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;


namespace Gestor2._0.Data.DB_BASE
{
    public partial class Bautizos
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public int? IdNombre { get; set; }

        [Display(Name = "Fecha")]
        public DateTime? FechaEvento { get; set; }

        [Display(Name = "Padre")]
        public int? IdPadre { get; set; }

        [Display(Name = "Madre")]
        public int? IdMadre { get; set; }

        [Display(Name = "Padrino")]
        public int? IdPadrino { get; set; }


        [Display(Name = "Madrina")]
        public int? IdMadrina { get; set; }

        [Display(Name = "Libro")]
        public int? Libro { get; set; }

        [Display(Name = "Folio")]
        public int? Folio { get; set; }

        [Display(Name = "Nota")]
        public string Nota { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime? FechaRegistro { get; set; }

        [Display(Name = "Registro")]
        public string NoRegistro { get; set; }


        [Display(Name = "Madre")]
        public virtual Personas IdMadreNavigation { get; set; }

        [Display(Name = "Madrina")]
        public virtual Personas IdMadrinaNavigation { get; set; }

        [Display(Name = "Nombre")]
        public virtual Personas IdNombreNavigation { get; set; }

        [Display(Name = "Padre")]
        public virtual Personas IdPadreNavigation { get; set; }


        [Display(Name = "Padrino")]
        public virtual Personas IdPadrinoNavigation { get; set; }
    }
}
