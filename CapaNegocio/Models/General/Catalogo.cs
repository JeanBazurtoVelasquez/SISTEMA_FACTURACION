using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.General
{
    public class Catalogo
    {
        public Catalogo()
        {
            
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Codigopadre { get; set; }
    }
}
