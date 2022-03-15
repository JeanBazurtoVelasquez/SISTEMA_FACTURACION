using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Pago
{
    public class Pago
    {
        public int Id { get; set; }
        public int Transaccionid { get; set; }
        public int Origenid { get; set; }
        public int Formapagoid { get; set; }
        public int Cuentabancariaid { get; set; }
        public decimal Monto { get; set; }
        public int Operador { get; set; }

    }
}
