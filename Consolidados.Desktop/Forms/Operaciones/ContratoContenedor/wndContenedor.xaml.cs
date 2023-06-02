using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Windows;

namespace Consolidados.Desktop.Forms.Operaciones.ContratoContenedor
{
    public partial class wndContenedor : MetroWindow
    {
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        BusinessLayer.ContratoContenedor bContenedor = new BusinessLayer.ContratoContenedor();
        BusinessLayer.Estado bEstado = new BusinessLayer.Estado();
        EntityLayer.ContratoContenedor contenedor;

        public wndContenedor(int IdContratoContenedor = 0)
        {
            InitializeComponent();
            CargarContrato();
            CargarEstado();

            if (IdContratoContenedor != 0)
            {
                var query = (from c in bContenedor.Listar("IdContratoContenedor", IdContratoContenedor)
                             select c).FirstOrDefault();

                cboContrato.SelectedValue = query.oContrato.IdContrato;
                txtNroContenedor.Text = query.NroContenedor;
                txtPayload.Value = query.Payload;
                cboEstado.SelectedValue = query.oEstado.IdEstado;
            }
        }

        void CargarContrato()
        {
            cboContrato.ItemsSource = null;
            cboContrato.ItemsSource = bContrato.Listar();
        }

        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = bEstado.Listar();
        }

        async void Guardar()
        {
            string Mensaje = string.Empty;

            contenedor = new EntityLayer.ContratoContenedor()
            {
                IdContratoContenedor = wndListaContenedor.IdContenedor,
                oContrato = new EntityLayer.Contrato()
                {
                    IdContrato = Convert.ToInt32(cboContrato.SelectedValue),
                    NroContratoLote = cboContrato.Text
                },
                NroContenedor = txtNroContenedor.Text,
                Payload = Convert.ToInt32(txtPayload.Value),
                oEstado = new EntityLayer.Estado()
                {
                    IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                    NombreEstado = cboEstado.Text
                }
            };

            if (wndListaContenedor.IdContenedor == 0)
            {
                if (bContenedor.Registrar(contenedor, out Mensaje) != 0)
                {
                    var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.AffirmativeAndNegative);
                    DialogResult = true;
                    Close();
                }
            }
            else if (bContenedor.Editar(contenedor, out Mensaje) == true)
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
            Close();
        }
    }
}