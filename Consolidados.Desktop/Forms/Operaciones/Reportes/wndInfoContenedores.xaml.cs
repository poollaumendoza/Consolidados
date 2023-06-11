using CrystalDecisions.CrystalReports.Engine;
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
using CrystalDecisions.Shared;

namespace Consolidados.Desktop.Forms.Operaciones.Reportes
{
    public partial class wndInfoContenedores : MetroWindow
    {
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();

        public wndInfoContenedores()
        {
            InitializeComponent();
            CargarContrato();
        }

        void CargarContrato()
        {
            cboContrato.ItemsSource = null;
            cboContrato.ItemsSource = bContrato.Listar();
        }

        void CargarReporte(int IdContrato = 0)
        {
            

        }

        private void BtnReportar_Click(object sender, RoutedEventArgs e)
        {
            int IdContrato = Convert.ToInt32(cboContrato.SelectedValue);
            CargarReporte(IdContrato);
        }
    }
}