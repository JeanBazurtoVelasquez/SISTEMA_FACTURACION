using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Models.General
{
    public class Persona
    {
        public Persona()
        {
        }

        public int Id { get; set; }
        public int Tipopersonaid { get; set; }
        public short Tiponip { get; set; }
        public string Nip { get; set; }
        public string Ruc { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int? Parroquiaid { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Sexo { get; set; }
        public string Fechanacimiento { get; set; }
    }
}
