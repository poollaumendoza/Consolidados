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
        public string Dirección { get; set; }
        public string Teléfono { get; set;}
        public string Email { get; set; }
        public Estado oEstado { get; set; }
    }
}