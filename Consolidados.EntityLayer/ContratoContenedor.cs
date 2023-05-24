using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class ContratoContenedor
    {
        public int IdContratoContenedor { get; set; }
        public Contrato oContrato { get; set; }
        public string NroContenedor { get; set; }
        public int Payload { get; set; }
        public Estado oEstado { get; set; }
    }
}