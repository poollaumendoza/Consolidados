using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public TipoMovimiento oTipoMovimiento { get; set; }
        public Empresa oEmpresa { get; set; }
        public Lote oLote { get; set; }
        public string FechaMovimiento { get; set; }
        public int StockInicial { get; set; }
        public int Ingreso { get; set; }
        public int Salida { get; set; }
        public int StockActual { set { _ = (StockInicial + Ingreso) - Salida; } }
        public Estado oEstado { get; set; }
    }
}