using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Inventario
{
    public class TipoTransaccion
    {
        public TipoTransaccion()
        {
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public short Operador { get; set; }
    }
}
