using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Contrato
    {
        public int IdContrato { get; set; }
        public Empresa oEmpresa { get; set; }
        public string NroContrato { get; set; }
        public string NroContratoLote { get; set; }
        public string FechaContrato { get; set; }
        public string FechaCarga { get; set; }
        public string LugarCarga { get; set; }
        public string FechaDescarga { get; set; }
        public string LugarDescarga { get; set; }
        public Estado oEstado { get; set; }
    }
}