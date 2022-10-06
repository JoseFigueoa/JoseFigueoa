using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Ubicaciones = new HashSet<Ubicaciones>();
        }

        public int Id { get; set; }
        public int IdPais { get; set; }
        public string Departamento { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual ICollection<Ubicaciones> Ubicaciones { get; set; }
    }
}
