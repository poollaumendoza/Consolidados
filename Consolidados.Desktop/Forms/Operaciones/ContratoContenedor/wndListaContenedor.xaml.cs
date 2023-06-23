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

namespace Consolidados.Desktop.Forms.Operaciones.ContratoContenedor
{
    public partial class wndListaContenedor : MetroWindow
    {
        BusinessLayer.ContratoContenedor bContenedor = new BusinessLayer.ContratoContenedor();
        MetroWindow oWindow;
        public static int IdContenedor;

        public wndListaContenedor()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.diccionario);
            CargarContenedores();
        }

        void CargarContenedores()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bContenedor.Listar();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            IdContenedor = (int)((Button)sender).CommandParameter;
            oWindow = new wndContenedor(IdContenedor);
            if (oWindow.ShowDialog() == true)
                CargarContenedores();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string Mensaje = string.Empty;
            IdContenedor = (int)((Button)sender).CommandParameter;
            if (bContenedor.Eliminar(IdContenedor, out Mensaje))
                await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
            else
                await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);

        }
    }
}