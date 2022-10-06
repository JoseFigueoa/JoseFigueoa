using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class ViewRegister
    {

        [Key]
        public int id { get; set; }
        public int max { get; set; }
    }
}
