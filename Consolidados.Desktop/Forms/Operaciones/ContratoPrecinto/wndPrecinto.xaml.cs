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

namespace Consolidados.Desktop.Forms.Operaciones.ContratoPrecinto
{
    public partial class wndPrecinto : MetroWindow
    {
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        BusinessLayer.ContratoContenedor bContenedor = new BusinessLayer.ContratoContenedor();
        BusinessLayer.ContratoPrecinto bPrecinto = new BusinessLayer.ContratoPrecinto();
        BusinessLayer.Estado bEstado = new BusinessLayer.Estado();

        EntityLayer.ContratoPrecinto precinto;

        public wndPrecinto(int IdPrecinto = 0)
        {
            InitializeComponent();

            CargarContrato();
            CargarContenedor();
            CargarEstado();

            if (IdPrecinto != 0)
            {
                var query = (from p in bPrecinto.Listar("IdContratoPrecinto", IdPrecinto)
                             select p).FirstOrDefault();

                cboContrato.SelectedValue = query.oContrato.IdContrato;
                cboContenedor.SelectedValue = query.oContratoContenedor.IdContratoContenedor;
                txtNroPrecinto.Text = query.NroPrecinto;
                cboEstado.SelectedValue = query.oEstado.IdEstado;
            }
        }

        void CargarContrato()
        {
            cboContrato.ItemsSource = null;
            cboContrato.ItemsSource = bContrato.Listar();
        }

        void CargarContenedor(int IdContrato = 0)
        {
            cboContenedor.ItemsSource = null;
            cboContenedor.ItemsSource = bContenedor.Listar("IdContrato", IdContrato);
        }

        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = bEstado.Listar();
        }

        async void Guardar()
        {
            string Mensaje = string.Empty;

            precinto = new EntityLayer.ContratoPrecinto()
            {
                IdContratoPrecinto = wndListaPrecinto.IdPrecinto,
                oContrato = new EntityLayer.Contrato()
                {
                    IdContrato = Convert.ToInt32(cboContrato.SelectedValue),
                    NroContratoLote = cboContrato.Text
                },
                oContratoContenedor = new EntityLayer.ContratoContenedor()
                {
                    IdContratoContenedor = Convert.ToInt32(cboContenedor.SelectedValue),
                    NroContenedor = cboContenedor.Text
                },
                NroPrecinto = txtNroPrecinto.Text,
                oEstado = new EntityLayer.Estado()
                {
                    IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                    NombreEstado = cboEstado.Text
                }
            };

            if (wndListaPrecinto.IdPrecinto == 0)
            {
                if (bPrecinto.Registrar(precinto, out Mensaje) != 0)
                {
                    var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
                    DialogResult = true;
                    Close();
                }
            }
            else if (bPrecinto.Editar(precinto, out Mensaje) == true)
            {
                var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
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

        private void CboContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IdContrato = Convert.ToInt32(cboContrato.SelectedValue);
            CargarContenedor(IdContrato);
        }
    }
}