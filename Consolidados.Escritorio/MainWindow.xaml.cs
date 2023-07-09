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
using System.Windows.Navigation;
using System.Windows.Shapes;
using C1.WPF;
using C1.WPF.DataGrid;

namespace Consolidados.Escritorio
{
    public partial class MainWindow : Window
    {
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();

        public MainWindow()
        {
            InitializeComponent();

            CargarContratos();
        }

        void CargarContratos()
        {
            dg.ItemsSource = null;
            dg.ItemsSource = bContrato.Listar();
        }
    }
}
