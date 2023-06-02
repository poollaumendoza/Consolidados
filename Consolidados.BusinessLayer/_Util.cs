using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class _Util
    {
        DataLayer._Util dUtil = new DataLayer._Util();

        public string CrearZip(string Directorio, string NombreArchivo)
        {
            return dUtil.CrearZip(Directorio, NombreArchivo);
        }
    }
}