using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Models
{
    public class Respuesta
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public Respuesta(int statusCode, string message, object data)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.data = data;
        }

    }
}
