using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class Personas
    {
        public Personas()
        {
            BautizosIdMadreNavigation = new HashSet<Bautizos>();
            BautizosIdMadrinaNavigation = new HashSet<Bautizos>();
            BautizosIdNombreNavigation = new HashSet<Bautizos>();
            BautizosIdPadreNavigation = new HashSet<Bautizos>();
            BautizosIdPadrinoNavigation = new HashSet<Bautizos>();
            ConfirmacionesIdMadrinaNavigation = new HashSet<Confirmaciones>();
            ConfirmacionesIdPadrinoNavigation = new HashSet<Confirmaciones>();
            ConfirmacionesIdPersonaNavigation = new HashSet<Confirmaciones>();
            EventoPersonas = new HashSet<EventoPersonas>();
            MatrimoniosIdEsposaNavigation = new HashSet<Matrimonios>();
            MatrimoniosIdEsposoNavigation = new HashSet<Matrimonios>();
            Telefonos = new HashSet<Telefonos>();
        }

        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string TercerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ApellidoCasada { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int IdUbicacion { get; set; }
        public int IdTipoPersona { get; set; }
        public int IdGenero { get; set; }

        public virtual Generos IdGeneroNavigation { get; set; }
        public virtual TipoPersonas IdTipoPersonaNavigation { get; set; }
        public virtual Ubicaciones IdUbicacionNavigation { get; set; }
        public virtual ICollection<Bautizos> BautizosIdMadreNavigation { get; set; }
        public virtual ICollection<Bautizos> BautizosIdMadrinaNavigation { get; set; }
        public virtual ICollection<Bautizos> BautizosIdNombreNavigation { get; set; }
        public virtual ICollection<Bautizos> BautizosIdPadreNavigation { get; set; }
        public virtual ICollection<Bautizos> BautizosIdPadrinoNavigation { get; set; }
        public virtual ICollection<Confirmaciones> ConfirmacionesIdMadrinaNavigation { get; set; }
        public virtual ICollection<Confirmaciones> ConfirmacionesIdPadrinoNavigation { get; set; }
        public virtual ICollection<Confirmaciones> ConfirmacionesIdPersonaNavigation { get; set; }
        public virtual ICollection<EventoPersonas> EventoPersonas { get; set; }
        public virtual ICollection<Matrimonios> MatrimoniosIdEsposaNavigation { get; set; }
        public virtual ICollection<Matrimonios> MatrimoniosIdEsposoNavigation { get; set; }
        public virtual ICollection<Telefonos> Telefonos { get; set; }
    }
}
