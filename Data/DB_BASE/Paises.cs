using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class Paises
    {
        public Paises()
        {
            Departamentos = new HashSet<Departamentos>();
        }

        public int Id { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<Departamentos> Departamentos { get; set; }
    }
}
