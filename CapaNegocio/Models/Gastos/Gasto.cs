using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Gastos
{
    public class Gasto
    {
        public Gasto()
        {
        }

        public int Id { get; set; }
        public int Personaid { get; set; }
        public string Numeroautorizacion { get; set; }
        public string Codigo { get; set; }
        public bool Edocumento { get; set; }
        public decimal Subtotal0 { get; set; }
        public decimal Subtotaliva { get; set; }
        public decimal Descuento0 { get; set; }
        public decimal Descuentoiva { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fechahora { get; set; }
        public int Usuarioid { get; set; }
        public int Empresaid { get; set; }
        public int Establecimientoid { get; set; }
    }
}
