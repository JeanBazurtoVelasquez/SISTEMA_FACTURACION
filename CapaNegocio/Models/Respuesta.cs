using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models
{
    public class Respuesta
    {
        public bool error { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public Respuesta()
        {
            error = true;
            message = "";
            data = null;
        }
    }
}
