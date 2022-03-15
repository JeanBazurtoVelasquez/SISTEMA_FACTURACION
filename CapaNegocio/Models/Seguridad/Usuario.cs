using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Seguridad
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public int Id { get; set; }
        public string usuario { get; set; }
        public string Clave { get; set; }
    }
}
