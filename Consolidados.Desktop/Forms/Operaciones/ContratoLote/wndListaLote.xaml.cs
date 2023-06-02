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
    public partial class wndListaLote : MetroWindow
    {
        public static int IdLote = 0;
        MetroWindow oWindow;
        BusinessLayer.Lote bLote = new BusinessLayer.Lote();

        public wndListaLote()
        {
            InitializeComponent();
            CargarLotes();
        }

        void CargarLotes()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bLote.Listar();
        }

        private void BtnLote_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndLote();
            if (oWindow.ShowDialog() == true)
                CargarLotes();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            IdLote = Convert.ToInt32(((Button)sender).CommandParameter);
            oWindow = new wndLote(IdLote);
            if (oWindow.ShowDialog() == true)
                CargarLotes();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string Mensaje = string.Empty;
            IdLote = Convert.ToInt32(((Button)sender).CommandParameter);
            if(bLote.Eliminar(IdLote, out Mensaje) == true)
            {
                var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
            }
        }
    }
}