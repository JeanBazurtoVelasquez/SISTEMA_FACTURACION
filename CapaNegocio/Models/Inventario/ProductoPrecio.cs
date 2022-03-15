using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Inventario
{
    public class ProductoPrecio
    {
        public int Id { get; set; }
        public int Productoid { get; set; }
        public int Establecimientoid { get; set; }
        public int Unidadid { get; set; }
        public decimal Precio1 { get; set; }
        public decimal Precio2 { get; set; }
        public decimal Precio3 { get; set; }
        public decimal Precio4 { get; set; }
        public decimal Precio5 { get; set; }
    }
}
