using Consolidados.Desktop.Properties;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Consolidados.Desktop.Forms.Operaciones.ContratoFoto
{
    public partial class wndEmpaquetar : MetroWindow
    {
        BusinessLayer._Util bUtil = new BusinessLayer._Util();
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        BusinessLayer.Archivo bArchivo = new BusinessLayer.Archivo();
        string Mensaje = string.Empty;

        public wndEmpaquetar()
        {
            InitializeComponent();
            CargarContrato();
        }

        void CargarContrato()
        {
            cboContrato.ItemsSource = null;
            cboContrato.ItemsSource = bContrato.Listar();
        }

        void CargarListaArchivos(int IdContrato)
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bArchivo.CLAP(IdContrato);
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            CargarListaArchivos(Convert.ToInt32(cboContrato.SelectedValue));
        }

        private async void BtnEmpaquetar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IdContrato = Convert.ToInt32(cboContrato.SelectedValue);
                string Directorio = string.Format("{0}\\{1}", Settings.Default.Photos, cboContrato.Text);
                string NombreArchivo = string.Format("{0}\\{1}{2}", Settings.Default.Zip, cboContrato.Text, ".zip");

                var message = await this.ShowMessageAsync("Consolidados", bUtil.CrearZip(Directorio, NombreArchivo), MessageDialogStyle.Affirmative);
            }
            catch (Exception ex)
            {
                var message = await this.ShowMessageAsync("Consolidados", ex.Message, MessageDialogStyle.Affirmative);
            }
        }

        private void BtnVerUbicacion_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", Settings.Default.Zip);
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}