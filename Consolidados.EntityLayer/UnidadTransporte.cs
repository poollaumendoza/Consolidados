using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class UnidadTransporte
    {
        public int IdUnidadTransporte { get; set; }
        public Entidad oEntidad { get; set; }
        public Transportista oTransportista { get; set; }
        public string PlacaTracto { get; set; }
        public Estado oEstado { get; set; }
    }
}