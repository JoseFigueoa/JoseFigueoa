using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class EventoEstados
    {
        public EventoEstados()
        {
            Eventos = new HashSet<Eventos>();
        }

        public int Id { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Eventos> Eventos { get; set; }
    }
}
