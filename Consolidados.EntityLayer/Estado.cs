using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.EntityLayer
{
    public class Estado : ViewModelBase
    {
        private int _IdEstado;
        private string _NombreEstado;
        private ObservableCollection<Estado> _ListaEstados;

        public int IdEstado
        {
            get { return _IdEstado; }
            set { _IdEstado = value; OnPropertyChanged("IdEstado"); }
        }
        
        public string NombreEstado
        {
            get { return _NombreEstado; }
            set { _NombreEstado = value; OnPropertyChanged("NombreEstado"); }
        }

        public ObservableCollection<Estado> ListaEstados
        {
            get { return _ListaEstados; }
            set { _ListaEstados = value; OnPropertyChanged("ListaEstados"); }
        }
    }
}