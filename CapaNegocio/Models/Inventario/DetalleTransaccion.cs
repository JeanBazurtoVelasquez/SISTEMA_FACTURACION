using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Inventario
{
    public class DetalleTransaccion
    {
        public int Id { get; set; }
        public int Transaccionid { get; set; }
        public int Productoid { get; set; }
        public string Lote { get; set; }
        public DateTime Fechavencimiento { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Stock { get; set; }
        public decimal Precio { get; set; }
        public decimal Preciocosto { get; set; }
        public decimal Valoriva { get; set; }
        public decimal? Descuento { get; set; }
    }
}
