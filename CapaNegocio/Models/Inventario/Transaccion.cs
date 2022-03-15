using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.Inventario
{
    public class Transaccion
    {
        public Transaccion()
        {
        }

        public int Id { get; set; }
        public int? Idcompartido { get; set; }
        public int Establecimientoid { get; set; }
        public int Tipotransaccionid { get; set; }
        public int Personaid { get; set; }
        public string Numeroautorizacion { get; set; }
        public string Codigo { get; set; }
        public decimal Subtotal0 { get; set; }
        public decimal Subtotaliva { get; set; }
        public decimal Descuento0 { get; set; }
        public decimal Descuentoiva { get; set; }
        public int Establecimientodestinoid { get; set; }
        public int Transaccionid { get; set; }
        public int Usuarioid { get; set; }
        public DateTime Fechahora { get; set; }
        public int Estadosri { get; set; }
        public bool Etransaccion { get; set; }
        public int Empresaid { get; set; }
    }
}
