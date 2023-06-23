using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace Consolidados.Desktop.Forms.Operaciones.Contrato
{
    public partial class wndListaContrato : MetroWindow
    {
        #region Variables
        MetroWindow oWindow;
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        public static int IdContrato;
        #endregion
        #region Métodos
        void CargarContratos()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bContrato.Listar();
        }
        #endregion

        public wndListaContrato()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.diccionario);
            CargarContratos();
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            IdContrato = (int)((Button)sender).CommandParameter;
            oWindow = new wndContrato(IdContrato);
            if (oWindow.ShowDialog() == true)
                CargarContratos();
        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string Mensaje = string.Empty;
            IdContrato = (int)((Button)sender).CommandParameter;
            if (bContrato.Eliminar(IdContrato, out Mensaje))
                await this.ShowMessageAsync("Consolidados", "Registro eliminado", MessageDialogStyle.Affirmative);
            else
                await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
            CargarContratos();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new wndContrato();
            if (oWindow.ShowDialog() == true)
                CargarContratos();
        }
    }
}