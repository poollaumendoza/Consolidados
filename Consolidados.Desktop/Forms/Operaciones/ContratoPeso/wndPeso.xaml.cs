using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Consolidados.Desktop.Forms.Operaciones.ContratoPeso
{
    public partial class wndPeso : MetroWindow
    {
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        BusinessLayer.ContratoContenedor bContenedor = new BusinessLayer.ContratoContenedor();
        BusinessLayer.ContratoPeso bPeso = new BusinessLayer.ContratoPeso();
        BusinessLayer.Estado bEstado = new BusinessLayer.Estado();

        EntityLayer.ContratoPeso peso;

        public wndPeso(int IdPeso = 0)
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.diccionario);
            CargarContrato();
            CargarContenedor();
            CargarEstado();

            if (IdPeso != 0)
            {
                var query = (from p in bPeso.Listar(IdPeso)
                             select p).FirstOrDefault();

                cboContrato.SelectedValue = query.oContrato.IdContrato;
                cboContenedor.SelectedValue = query.oContratoContenedor.IdContratoContenedor;
                txtPeso.Value = query.PesoTotal;
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

            peso = new EntityLayer.ContratoPeso()
            {
                IdContratoPeso = wndListaPeso.IdPeso,
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
                PesoTotal = Convert.ToInt32(txtPeso.Value),
                oEstado = new EntityLayer.Estado()
                {
                    IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                    NombreEstado = cboEstado.Text
                }
            };

            if (wndListaPeso.IdPeso == 0)
            {
                if (bPeso.Registrar(peso, out Mensaje) != 0)
                {
                    var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
                    DialogResult = true;
                    Close();
                }
            }
            else if (bPeso.Editar(peso, out Mensaje) == true)
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