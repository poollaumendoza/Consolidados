using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public ClasificacionTipoDocumento oClasificacionTipoDocumento { get; set; } 
        public string NombreTipoDocumento { get; set; }
        public Estado oEstado { get; set; }
    }
}