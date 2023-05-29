using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace Consolidados.Desktop.Forms.Operaciones.Contrato
{
    public partial class wndListaContrato : MetroWindow
    {
        MetroWindow oWindow;
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        public static int IdContrato;

        public wndListaContrato()
        {
            InitializeComponent();
            CargarContratos();
        }

        void CargarContratos()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bContrato.Listar();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            IdContrato = (int)((Button)sender).CommandParameter;
            oWindow = new wndContrato(IdContrato);
            if (oWindow.ShowDialog() == true)
                CargarContratos();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndContrato();
            if (oWindow.ShowDialog() == true)
                CargarContratos();
        }
    }
}