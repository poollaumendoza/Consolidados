using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class ContratoPeso
    {
        public int IdContratoPeso { get; set; }
        public Contrato oContrato { get; set; }
        public ContratoContenedor oContratoContenedor { get; set; }
        public int PesoTotal { get; set; }
        public Estado oEstado { get; set; }
    }
}