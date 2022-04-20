using CapaNegocio.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.ViewModels.Inventario
{
    public class ProductoVenta
    {
        public Producto producto { get; set; }
        public List<ProductoPrecio> listaPrecios { get; set; }
        public int establecimientoid { get; set; }
    }
}
