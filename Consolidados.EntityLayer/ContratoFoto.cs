using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class ContratoFoto
    {
        public int IdContratoFoto { get; set; }
        public Contrato oContrato { get; set; }
        public ContratoContenedor oContratoContenedor { get; set; }
        public byte[] Foto { get; set; }
        public Estado oEstado { get; set; }
    }
}