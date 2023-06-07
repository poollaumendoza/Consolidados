using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
   public class Recursos
    {
        public static string ConvertirBase64(string rutaImagen, out bool conversion)
        {
            string textoBase64 = string.Empty;
            conversion = true;

            try {textoBase64 = Convert.ToBase64String(File.ReadAllBytes(rutaImagen)); }
            catch { conversion = false; }

            return textoBase64;
        }
    }
}