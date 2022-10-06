using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class Eventos
    {
        public Eventos()
        {
            EventoPersonas = new HashSet<EventoPersonas>();
        }

        public int Id { get; set; }
        public int IdTipoEvento { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaPrograma { get; set; }
        public int? NoRegistro { get; set; }
        public int? NoLibro { get; set; }
        public int? NoFolio { get; set; }

        public virtual EventoEstados IdEstadoNavigation { get; set; }
        public virtual TipoEventos IdTipoEventoNavigation { get; set; }
        public virtual ICollection<EventoPersonas> EventoPersonas { get; set; }
    }
}
