using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Consolidados.Desktop.Forms.Operaciones.ContratoLote
{
    public partial class wndLote : MetroWindow
    {
        BusinessLayer.Almacen bAlmacen = new BusinessLayer.Almacen();
        BusinessLayer.Empresa bEmpresa = new BusinessLayer.Empresa();
        BusinessLayer.Estado bEstado = new BusinessLayer.Estado();
        BusinessLayer.Lote bLote = new BusinessLayer.Lote();

        EntityLayer.Lote lote;

        public wndLote(int IdLote = 0)
        {
            InitializeComponent();
            CargarAlmacen();
            CargarEmpresa();
            CargarEstado();

            if(IdLote != 0)
            {
                var query = (from l in bLote.Listar(IdLote)
                             select l).FirstOrDefault();

                cboEmpresa.SelectedValue = query.oEmpresa.IdEmpresa;
                cboAlmacen.SelectedValue = query.oAlmacen.IdAlmacen;
                txtDescripcion.Text = query.Descripcion;
                txtNroLote.Text = query.NroLote;
                txtCantidad.Value = query.Cantidad;
                cboEstado.SelectedValue = query.oEstado.IdEstado;
            }
        }

        void CargarEmpresa()
        {
            cboEmpresa.ItemsSource = null;
            cboEmpresa.ItemsSource = bEmpresa.Listar();
        }

        void CargarAlmacen()
        {
            cboAlmacen.ItemsSource = null;
            cboAlmacen.ItemsSource = bAlmacen.Listar();
        }

        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = bEstado.Listar();
        }

        async void Guardar()
        {
            string Mensaje = string.Empty;

            lote = new EntityLayer.Lote()
            {
                IdLote = wndListaLote.IdLote,
                oAlmacen = new EntityLayer.Almacen()
                {
                    IdAlmacen = Convert.ToInt32(cboAlmacen.SelectedValue),
                    NombreAlmacen = cboAlmacen.Text
                },
                oEmpresa = new EntityLayer.Empresa()
                {
                    IdEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue),
                    RazonSocial = cboEmpresa.Text
                },
                Descripcion = txtDescripcion.Text,
                NroLote = txtNroLote.Text,
                Cantidad = Convert.ToInt32(txtCantidad.Value),
                oEstado = new EntityLayer.Estado()
                {
                    IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                    NombreEstado = cboEstado.Text
                }
            };

            if (wndListaLote.IdLote == 0)
            {
                if (bLote.Registrar(lote, out Mensaje) != 0)
                {
                    var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.AffirmativeAndNegative);
                    DialogResult = true;
                    Close();
                }
            }
            else if (bLote.Editar(lote, out Mensaje) == true)
            {
                var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.AffirmativeAndNegative);
                DialogResult = true;
                Close();
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}