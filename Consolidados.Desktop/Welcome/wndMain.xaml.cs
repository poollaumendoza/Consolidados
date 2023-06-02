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

namespace Consolidados.Desktop.Welcome
{
    public partial class wndMain : MetroWindow
    {
        MetroWindow oWindow;

        public wndMain()
        {
            InitializeComponent();
        }

        private void TlbContratos_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Operaciones.Contrato.wndListaContrato();
            oWindow.ShowDialog();
        }

        private void TlbLotes_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Operaciones.ContratoLote.wndListaLote();
            oWindow.ShowDialog();
        }

        private void TlbPesos_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Operaciones.ContratoPeso.wndListaPeso();
            oWindow.ShowDialog();
        }

        private void TlbContenedores_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Operaciones.ContratoContenedor.wndListaContenedor();
            oWindow.ShowDialog();
        }

        private void TlbPrecintos_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Operaciones.ContratoPrecinto.wndListaPrecinto();
            oWindow.ShowDialog();
        }

        private void TlbFotos_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Operaciones.ContratoFoto.wndListaFoto();
            oWindow.ShowDialog();
        }

        private void TlbReportes_Click(object sender, RoutedEventArgs e)
        {
            oWindow = new Forms.Operaciones.Reportes.wndListaReportes();
            oWindow.ShowDialog();
        }
    }
}