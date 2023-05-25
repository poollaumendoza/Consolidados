using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Entidad
    {
        public int IdEntidad { get; set; }
        public TipoDocumento oTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set;}
        public string Email { get; set; }
        public Estado oEstado { get; set; }
    }
}