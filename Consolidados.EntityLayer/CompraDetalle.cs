using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class CompraDetalle
    {
        public int IdCompraDetalle { get; set; }
        public Compra oCompra { get; set; }
        public Lote oLote { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public Estado oEstado { get; set; }
    }
}