using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class ContratoPrecinto
    {
        public int IdContratoPrecinto { get; set; }
        public Contrato oContrato { get; set; }
        public ContratoContenedor oContratoContenedor { get; set; }
        public string NroPrecinto { get; set; }
        public Estado oEstado { get; set; }
    }
}