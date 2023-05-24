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
        public string NroLote { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime FechaCarga { get; set; }
        public string LugarCarga { get; set; }
        public DateTime FechaDescarga { get; set; }
        public string LugarDescarga { get; set; }
        public Estado oEstado { get; set; }
    }
}