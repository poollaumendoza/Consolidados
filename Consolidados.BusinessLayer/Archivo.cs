using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class Archivo
    {
        DataLayer.Archivo dArchivo = new DataLayer.Archivo();

        public List<EntityLayer.Archivo> CLAP(int IdContrato)
        {
            return dArchivo.CargarListaArchivosPaquete(IdContrato);
        }
    }
}