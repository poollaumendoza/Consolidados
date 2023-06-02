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

namespace Consolidados.Desktop.Forms.Operaciones.ContratoPeso
{
    public partial class wndListaPeso : MetroWindow
    {
        public static int IdPeso;
        MetroWindow oWindow;
        BusinessLayer.ContratoPeso bPeso = new BusinessLayer.ContratoPeso();

        public wndListaPeso()
        {
            InitializeComponent();
            CargarPesos();
        }

        void CargarPesos()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bPeso.Listar();
        }

        private void BtnPeso_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndPeso();
            if (oWindow.ShowDialog() == true)
                CargarPesos();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            IdPeso = Convert.ToInt32(((Button)sender).CommandParameter);
            oWindow = new wndPeso(IdPeso);
            if (oWindow.ShowDialog() == true)
                CargarPesos();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string Mensaje = string.Empty;
            IdPeso = Convert.ToInt32(((Button)sender).CommandParameter);
            if (bPeso.Eliminar(IdPeso, out Mensaje))
            {
                var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
            }
        }
    }
}