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

        public int Id { get; set; }
        public string Ruc { get; set; }
        public string Nombre { get; set; }
        public string Actividadcomercial { get; set; }
    }
}
