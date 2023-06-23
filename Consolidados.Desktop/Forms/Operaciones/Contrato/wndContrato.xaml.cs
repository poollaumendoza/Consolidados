using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Windows;

namespace Consolidados.Desktop.Forms.Operaciones.Contrato
{
    public partial class wndContrato : MetroWindow
    {
        #region Variables
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        BusinessLayer.Empresa bEmpresa = new BusinessLayer.Empresa();
        BusinessLayer.Estado bEstado = new BusinessLayer.Estado();
        EntityLayer.Contrato contrato;
        #endregion
        #region Métodos
        async void Guardar()
        {
            string Mensaje = string.Empty;
            if (wndListaContrato.IdContrato == 0)
            {
                contrato = new EntityLayer.Contrato()
                {
                    oEmpresa = new EntityLayer.Empresa()
                    {
                        IdEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue),
                        RazonSocial = cboEmpresa.Text
                    },
                    NroContrato = txtContrato.Text,
                    NroContratoLote = txtContratoLote.Text,
                    FechaContrato = dtpFechaContrato.Text,
                    FechaCarga = dtpFechaCarga.Text,
                    FechaDescarga = dtpFechaDescarga.Text,
                    LugarCarga = txtLugarCarga.Text,
                    LugarDescarga = txtLugarDescarga.Text,
                    oEstado = new EntityLayer.Estado()
                    {
                        IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                        NombreEstado = cboEstado.Text
                    }
                };
                if (bContrato.Registrar(contrato, out Mensaje) > 0)
                {
                    var mensaje = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
                    DialogResult = true;
                }
            }
            else
            {
                contrato = new EntityLayer.Contrato()
                {
                    IdContrato = wndListaContrato.IdContrato,
                    oEmpresa = new EntityLayer.Empresa()
                    {
                        IdEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue),
                        RazonSocial = cboEmpresa.Text
                    },
                    NroContrato = txtContrato.Text,
                    NroContratoLote = txtContratoLote.Text,
                    FechaContrato = dtpFechaContrato.Text,
                    FechaCarga = dtpFechaCarga.Text,
                    FechaDescarga = dtpFechaDescarga.Text,
                    LugarCarga = txtLugarCarga.Text,
                    LugarDescarga = txtLugarDescarga.Text,
                    oEstado = new EntityLayer.Estado()
                    {
                        IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                        NombreEstado = cboEstado.Text
                    }
                };
                if (bContrato.Editar(contrato, out Mensaje))
                {
                    var mensaje = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
                    DialogResult = true;
                }
            }
        }
        void CargarEmpresa()
        {
            cboEmpresa.ItemsSource = null;
            cboEmpresa.ItemsSource = bEmpresa.Listar();
        }
        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = bEstado.Listar();
        }
        #endregion

        public wndContrato(int IdContrato = 0)
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.diccionario);
            CargarEmpresa();
            CargarEstado();

            if (IdContrato != 0)
            {
                var query = (from c in bContrato.Listar(IdContrato)
                             select c).FirstOrDefault();

                cboEmpresa.SelectedValue = query.oEmpresa.IdEmpresa;
                txtContrato.Text = query.NroContrato;
                txtContratoLote.Text = query.NroContratoLote;
                dtpFechaContrato.Text = query.FechaContrato;
                dtpFechaCarga.Text = query.FechaCarga;
                txtLugarCarga.Text = query.LugarCarga;
                dtpFechaDescarga.Text = query.FechaDescarga;
                txtLugarDescarga.Text = query.LugarDescarga;
                cboEstado.SelectedValue = query.oEstado.IdEstado;
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