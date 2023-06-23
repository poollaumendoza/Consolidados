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

namespace Consolidados.Desktop.Forms.Operaciones.ContratoFoto
{
    public partial class wndListaFoto : MetroWindow
    {
        MetroWindow oWindow;
        BusinessLayer.ContratoFoto bFoto = new BusinessLayer.ContratoFoto();
        public static int IdFoto;
        string Mensaje = string.Empty;

        public wndListaFoto()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.diccionario);
            CargarFoto();
        }

        void CargarFoto()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bFoto.Listar();
        }

        private void BtnFoto_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndFoto();
            if (oWindow.ShowDialog() == true)
                CargarFoto();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            IdFoto = Convert.ToInt32(((Button)sender).CommandParameter);
            oWindow = new wndFoto(IdFoto);
            if (oWindow.ShowDialog() == true)
                CargarFoto();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            IdFoto = Convert.ToInt32(((Button)sender).CommandParameter);
            bFoto.Eliminar(IdFoto, out Mensaje);
            var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
        }

        private void BtnBuscarNueva_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmpaquetar_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndEmpaquetar();
            oWindow.ShowDialog();
        }
    }
}