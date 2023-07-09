using System.Collections.ObjectModel;

namespace Consolidados.EntityLayer
{
    public class Almacen : ViewModelBase
    {
        int _IdAlmacen;
        string _NombreAlmacen;
        string _Direccion;
        Estado _oEstado;
        ObservableCollection<Almacen> _ListaAlmacen;

        public int IdAlmacen
        {
            get { return _IdAlmacen; }
            set
            {
                _IdAlmacen = value;
                OnPropertyChanged("IdAlmacen");
            }
        }

        public string NombreAlmacen
        {
            get { return _NombreAlmacen; }
            set
            {
                _NombreAlmacen = value;
                OnPropertyChanged("NombreAlmacen");
            }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set
            {
                _Direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        public Estado oEstado
        {
            get { return _oEstado; }
            set
            {
                _oEstado = value;
                OnPropertyChanged("oEstado");
            }
        }

        public ObservableCollection<Almacen> ListaAlmacen
        {
            get { return _ListaAlmacen; }
            set { _ListaAlmacen = value; OnPropertyChanged("ListaAlmacen"); }
        }
    }
}