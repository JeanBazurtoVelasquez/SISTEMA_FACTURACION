using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Inventario
{
    public class Lote
    {
        public int Productoid { get; set; }
        public int Establecimientoid { get; set; }
        public string Lote1 { get; set; }
        public DateTime Fechavencimiento { get; set; }
        public decimal Preciocosto { get; set; }
        public decimal Stock { get; set; }
        public DateTime Fecharegistro { get; set; }
        public int Usuarioregistro { get; set; }
        public DateTime Fechaactualizacion { get; set; }
        public int Usuarioactualizacion { get; set; }
    }
}
