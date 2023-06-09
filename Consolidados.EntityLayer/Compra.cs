using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Empresa oEmpresa { get; set; }
        public Entidad oEntidad { get; set; }
        public TipoDocumento oTipoDocumento { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public string FechaCompra { get; set; }
        public decimal Importe { get; set; }
        public decimal IGV { get; set; }
        public decimal Total { get; set; }
        public Estado oEstado { get; set; }
    }
}