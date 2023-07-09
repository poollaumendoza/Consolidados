using Consolidados.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Consolidados.MVVM.ViewModels
{
    public class AlmacenViewModel
    {
        #region Variables
        ICommand _comandoGuardar;
        ICommand _comandoLimpiar;
        ICommand _comandoModificar;
        ICommand _comandoEliminar;
        ICommand _comandoListarEstados;
        Almacen _almacen = null;
        Estado _estado = null;
        ObservableCollection<Estado> _ListaEstado;
        public Almacen AlmacenRegistro { get; set; }
        BusinessLayer.Almacen bAlmacen = new BusinessLayer.Almacen();
        BusinessLayer.Estado bEstado = new BusinessLayer.Estado();
        #endregion
        #region Comandos
        public ICommand ComandoLimpiar
        {
            get
            {
                if (_comandoLimpiar == null)
                    _comandoLimpiar = new RelayCommand(param => LimpiarDatos(), null);
                return _comandoLimpiar;
            }
        }
        public ICommand ComandoGuardar
        {
            get
            {
                if (_comandoGuardar == null)
                    _comandoGuardar = new RelayCommand(param => GuardarDatos(), null);
                return _comandoGuardar;
            }
        }
        public ICommand ComandoModificar
        {
            get
            {
                if (_comandoModificar == null)
                    _comandoModificar = new RelayCommand(param => ModificarDatos((int)param), null);
                return _comandoModificar;
            }
        }
        public ICommand ComandoEliminar
        {
            get
            {
                if (_comandoEliminar == null)
                    _comandoEliminar = new RelayCommand(param => EliminarDatos((int)param), null);

                return _comandoEliminar;
            }
        }
        #endregion
        #region Métodos
        void LimpiarDatos()
        {
            AlmacenRegistro.IdAlmacen = 0;
            AlmacenRegistro.NombreAlmacen = string.Empty;
            AlmacenRegistro.Direccion = string.Empty;
            AlmacenRegistro.oEstado.IdEstado = 1;
        }
        private void GuardarDatos()
        {
            string Mensaje = string.Empty;

            if (AlmacenRegistro != null)
            {
                _almacen.NombreAlmacen = AlmacenRegistro.NombreAlmacen;
                _almacen.Direccion = AlmacenRegistro.Direccion;
                _almacen.oEstado.IdEstado = AlmacenRegistro.oEstado.IdEstado;

                try
                {
                    if (AlmacenRegistro.IdAlmacen <= 0)
                    {
                        bAlmacen.Registrar(_almacen, out Mensaje);
                        MessageBox.Show(Mensaje);
                    }
                    else
                    {
                        _almacen.IdAlmacen = AlmacenRegistro.IdAlmacen;
                        bAlmacen.Editar(_almacen, out Mensaje);
                        MessageBox.Show(Mensaje);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ObtenerTodo();
                    LimpiarDatos();
                }
            }
        }
        private void ModificarDatos(int id)
        {
            var model = bAlmacen.Listar(id);
            AlmacenRegistro.IdAlmacen = model.IdAlmacen;
            AlmacenRegistro.NombreAlmacen = model.NombreAlmacen;
            AlmacenRegistro.Direccion = model.Direccion;
            AlmacenRegistro.oEstado.IdEstado = model.oEstado.IdEstado;
        }
        private void EliminarDatos(int IdAlmacen)
        {
            string Mensaje = string.Empty;

            if (MessageBox.Show("Desea eliminar este registro?", "Estudiantes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    bAlmacen.Eliminar(IdAlmacen, out Mensaje);
                    MessageBox.Show("Registro eliminado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //ObtenerTodo();
                }
            }
        }
        private void ObtenerTodo()
        {
            AlmacenRegistro.ListaAlmacen = new ObservableCollection<Almacen>();
            bAlmacen.Listar().ForEach(data => AlmacenRegistro.ListaAlmacen.Add(new Almacen()
            {
                IdAlmacen = data.IdAlmacen,
                NombreAlmacen = data.NombreAlmacen,
                Direccion = data.Direccion,
                oEstado = new Estado()
                {
                    IdEstado = data.oEstado.IdEstado,
                    NombreEstado = data.oEstado.NombreEstado
                }
            }));
        }
        private void ListarEstados()
        {
            foreach (var data in bEstado.Listar())
            {
                _estado.ListaEstados.Add(new Estado()
                {
                    IdEstado = data.IdEstado,
                    NombreEstado = data.NombreEstado
                });
            }
        }
        #endregion
        public AlmacenViewModel()
        {
            _almacen = new Almacen();
            _estado = new Estado();
            AlmacenRegistro = new Almacen();
            ObtenerTodo();
        }
    }
}