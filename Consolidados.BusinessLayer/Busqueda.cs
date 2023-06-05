using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class Busqueda
    {
        DataLayer.Busqueda dBusqueda = new DataLayer.Busqueda();

        public DataTable Listar(string seleccion, string criterio)
        {
            return dBusqueda.Listar(seleccion, criterio);
        }
    }
}