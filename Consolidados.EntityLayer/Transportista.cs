using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Transportista
    {
        public int IdTransportista { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string LicConducir { get; set; }
        public string Telefono { get; set; }
        public Estado oEstado { get; set; }
    }
}