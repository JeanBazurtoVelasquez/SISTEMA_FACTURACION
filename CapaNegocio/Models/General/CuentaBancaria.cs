using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.General
{
    public class CuentaBancaria
    {
        public CuentaBancaria()
        {
        }

        public int Id { get; set; }
        public int Entidadfinancieraid { get; set; }
        public string Tipocuenta { get; set; }
        public string Numerocuenta { get; set; }
        public int Personaid { get; set; }
    }
}
