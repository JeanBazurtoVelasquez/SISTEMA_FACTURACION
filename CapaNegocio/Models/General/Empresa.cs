using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.General
{
    public class Empresa
    {
        public Empresa()
        {
        }

        public int id { get; set; }
        public string ruc { get; set; }
        public string nombre { get; set; }
        public string actividadcomercial { get; set; }
    }
}
