using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Archivo : ViewModelBase
    {
        private string _NroContrato;
        private string _NroContenedor;
        private string _NombreArchivo;

        public string NroContrato
        {
            get { return _NroContrato; }
            set { _NroContrato = value; OnPropertyChanged("NroContrato"); }
        }

        public string NroContenedor
        {
            get { return _NroContenedor; }
            set { _NroContenedor = value; OnPropertyChanged("NroContenedor"); }
        }
        
        public string NombreArchivo
        {
            get { return _NombreArchivo; }
            set { _NombreArchivo = value; OnPropertyChanged("NombreArchivo"); }
        }
    }
}