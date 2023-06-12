using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class ContratoTransporte
    {
        public int IdContratoTransporte { get; set; }
        public UnidadTransporte oUnidadTransporte { get; set; }
        public Contrato oContrato { get; set; }
        public Lote oLote { get; set; }
        public int Cantidad { get; set; }
        public int Peso { get; set; }
        public Estado oEstado { get; set; }
    }
}