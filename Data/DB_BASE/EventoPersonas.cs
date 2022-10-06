using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class EventoPersonas
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdEvento { get; set; }
        public int IdEventoPersona { get; set; }

        public virtual Eventos IdEventoNavigation { get; set; }
        public virtual EventoTipoPersonas IdEventoPersonaNavigation { get; set; }
        public virtual Personas IdPersonaNavigation { get; set; }
    }
}
