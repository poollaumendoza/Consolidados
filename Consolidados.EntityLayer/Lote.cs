using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Lote
    {
        public int IdLote { get; set; }
        public Almacen oAlmacen { get; set; }
        public Empresa oEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string NroLote { get; set; }
        public int Cantidad { get; set; }
        public int Peso { get; set; }
        public Estado oEstado { get; set; }
    }
}