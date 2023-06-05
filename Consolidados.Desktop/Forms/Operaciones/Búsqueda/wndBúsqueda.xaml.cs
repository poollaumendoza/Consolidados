using MahApps.Metro.Controls;
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

namespace Consolidados.Desktop.Forms.Operaciones.Búsqueda
{
    public partial class wndBúsqueda : MetroWindow
    {
        BusinessLayer.Busqueda bBusqueda = new BusinessLayer.Busqueda();

        public wndBúsqueda()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = null;

            if (rbContrato.IsChecked == true)
                dg.ItemsSource = bBusqueda.Listar(rbContrato.Content.ToString().ToLower(), txtBuscar.Text).DefaultView;
            else if (rbContenedor.IsChecked == true)
                dg.ItemsSource = bBusqueda.Listar(rbContenedor.Content.ToString().ToLower(), txtBuscar.Text).DefaultView;
            else if (rbFoto.IsChecked == true)
                dg.ItemsSource = bBusqueda.Listar(rbFoto.Content.ToString().ToLower(), txtBuscar.Text).DefaultView;
            else if (rbLote.IsChecked == true)
                dg.ItemsSource = bBusqueda.Listar(rbLote.Content.ToString().ToLower(), txtBuscar.Text).DefaultView;
            else if (rbPrecinto.IsChecked == true)
                dg.ItemsSource = bBusqueda.Listar(rbPrecinto.Content.ToString().ToLower(), txtBuscar.Text).DefaultView;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}