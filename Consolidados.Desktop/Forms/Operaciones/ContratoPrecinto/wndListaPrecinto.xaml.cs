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
    public partial class wndListaPrecinto : MetroWindow
    {
        public static int IdPrecinto;
        MetroWindow oWindow;
        BusinessLayer.ContratoPrecinto bPrecinto = new BusinessLayer.ContratoPrecinto();

        public wndListaPrecinto()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.diccionario);
            CargarPrecintos();
        }

        void CargarPrecintos()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bPrecinto.Listar();
        }

        private void BtnPeso_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndPrecinto();
            if (oWindow.ShowDialog() == true)
                CargarPrecintos();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            IdPrecinto = Convert.ToInt32(((Button)sender).CommandParameter);
            oWindow = new wndPrecinto(IdPrecinto);
            if (oWindow.ShowDialog() == true)
                CargarPrecintos();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string Mensaje = string.Empty;
            IdPrecinto = Convert.ToInt32(((Button)sender).CommandParameter);
            if (bPrecinto.Eliminar(IdPrecinto, out Mensaje))
            {
                var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
            }
        }
    }
}