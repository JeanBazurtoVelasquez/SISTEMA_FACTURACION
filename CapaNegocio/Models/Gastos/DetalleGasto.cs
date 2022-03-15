using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Gastos
{
    public class DetalleGasto
    {
        public int Id { get; set; }
        public int Gastoid { get; set; }
        public int? Productoid { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Valoriva { get; set; }

        public DetalleGasto()
        {

        }
    }
}
