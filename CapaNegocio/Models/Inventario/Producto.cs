using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Inventario
{
    public class Producto
    {
        public Producto()
        {
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Codigobarra { get; set; }
        public string Nombre { get; set; }
        public decimal? Pvp { get; set; }
        public bool Grabaiva { get; set; }
        public int Categoriaid { get; set; }
        public int Empresaid { get; set; }
    }
}
