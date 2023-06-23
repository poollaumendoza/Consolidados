using Consolidados.Desktop.Properties;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Consolidados.Desktop.Welcome
{
    public partial class wndLogin : MetroWindow
    {
        #region Variables
        MetroWindow oWindow;
        List<Pais> listaPaises = new List<Pais>();
        BusinessLayer.Usuario bUsuario = new BusinessLayer.Usuario();
        #endregion
        #region Métodos
        void CargarPaises()
        {
            listaPaises.Clear();
            listaPaises.Add(new Pais() { Valor = "es", Bandera = "/Resources/spain.png", NombrePais = "Español" });
            listaPaises.Add(new Pais() { Valor = "en", Bandera = "/Resources/united-states.png", NombrePais = "Inglés" });
            listaPaises.Add(new Pais() { Valor = "zh", Bandera = "/Resources/china.png", NombrePais = "Chino" });

            cboLenguaje.ItemsSource = null;
            cboLenguaje.ItemsSource = listaPaises;
            cboLenguaje.SelectedValuePath = "Valor";
            cboLenguaje.SelectedIndex = 0;
        }
        void CambiarLenguaje(string languageCode = "")
        {
            switch (languageCode)
            {
                case "es":
                    App.diccionario.Source = new Uri("..\\Resources\\Lang.es-ES.xaml", UriKind.Relative);
                    break;
                case "en":
                    App.diccionario.Source = new Uri("..\\Resources\\Lang.en-US.xaml", UriKind.Relative);
                    break;
                case "zh":
                    App.diccionario.Source = new Uri("..\\Resources\\Lang.zh-CN.xaml", UriKind.Relative);
                    break;
                default:
                    App.diccionario.Source = new Uri("..\\Resources\\Lang.es-ES.xaml", UriKind.Relative);
                    break;
            }
            Resources.MergedDictionaries.Add(App.diccionario);
            Settings.Default.languageCode = languageCode;
        }
        bool Ingresar(string usuario, string contraseña)
        {
            EntityLayer.Usuario eUsuario = new EntityLayer.Usuario();
            eUsuario = bUsuario.BuscarUsuario(usuario, contraseña);

            if (eUsuario.NombreUsuario == usuario && eUsuario.Contraseña == contraseña)
                return true;
            else
                return false;
        }
        #endregion
        #region Clases
        public class Pais
        {
            public string Valor { get; set; }
            public string Bandera { get; set; }
            public string NombrePais { get; set; }
        }
        #endregion

        public wndLogin()
        {
            InitializeComponent();
            CargarPaises();
            CambiarLenguaje("es");
        }

        private void CboLenguaje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CambiarLenguaje(cboLenguaje.SelectedValue.ToString());
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtNombreUsuario.Text;
            string contraseña = txtContraseña.Password;

            if (Ingresar(usuario, contraseña))
            {
                oWindow = new wndMain();
                oWindow.ShowDialog();
            }
            else
                return;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}