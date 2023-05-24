using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public  class ClasificacionTipoDocumento
    {
        public int IdClasificacionTipoDocumento { get; set; }
        public string NombreClasificacionTipoDocumento { get; set; }
        public Estado oEstado { get; set; }
    }
}