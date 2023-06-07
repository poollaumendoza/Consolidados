using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Configuration;
using Consolidados.Desktop.Properties;

namespace Consolidados.Desktop.Forms.Operaciones.ContratoFoto
{
    public partial class wndFoto : MetroWindow
    {
        #region Variables
        BusinessLayer.Contrato bContrato = new BusinessLayer.Contrato();
        BusinessLayer.ContratoContenedor bContenedor = new BusinessLayer.ContratoContenedor();
        BusinessLayer.Estado bEstado = new BusinessLayer.Estado();
        BusinessLayer.ContratoFoto bFoto = new BusinessLayer.ContratoFoto();
        EntityLayer.ContratoFoto foto = new EntityLayer.ContratoFoto();
        OpenFileDialog ofd = new OpenFileDialog();
        List<Fotos> listaFotos = new List<Fotos>();
        string Mensaje = string.Empty;
        string rutaarchivo = string.Empty;
        #endregion
        #region Métodos
        void CargarContrato()
        {
            cboContrato.ItemsSource = null;
            cboContrato.ItemsSource = bContrato.Listar();
        }
        void CargarContenedor(int IdContrato = 0)
        {
            cboContenedor.ItemsSource = null;
            cboContenedor.ItemsSource = bContenedor.Listar("IdContrato", IdContrato);
        }
        void CargarEstado()
        {
            cboEstado.ItemsSource = null;
            cboEstado.ItemsSource = bEstado.Listar();
        }
        void SubirFotos(bool multiple, OpenFileDialog ofd)
        {
            switch (multiple)
            {
                case true:
                    imgFoto.Source = null;

                    ofd = new OpenFileDialog();
                    ofd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                    ofd.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                    ofd.Multiselect = true;

                    if (ofd.ShowDialog() == true)
                        foreach (string archivo in ofd.FileNames)
                            listaFotos.Add(new Fotos() { Imagen = archivo });

                    dg.ItemsSource = null;
                    dg.ItemsSource = listaFotos;

                    grpSimple.Visibility = System.Windows.Visibility.Hidden;
                    grpMultiple.Visibility = System.Windows.Visibility.Visible;
                    break;
                case false:
                    listaFotos.Clear();

                    ofd = new OpenFileDialog();
                    ofd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                    ofd.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                    ofd.Multiselect = true;

                    if (ofd.ShowDialog() == true)
                        imgFoto.Source = new BitmapImage(new Uri(ofd.FileName));

                    grpSimple.Visibility = System.Windows.Visibility.Visible;
                    grpMultiple.Visibility = System.Windows.Visibility.Hidden;
                    break;
            }
        }
        async void Guardar()
        {
            if (listaFotos.Count > 0)
            {
                foreach (var item in listaFotos)
                {
                    foto = new EntityLayer.ContratoFoto()
                    {
                        oContrato = new EntityLayer.Contrato()
                        {
                            IdContrato = Convert.ToInt32(cboContrato.SelectedValue),
                            NroContratoLote = cboContrato.Text
                        },
                        oContratoContenedor = new EntityLayer.ContratoContenedor()
                        {
                            IdContratoContenedor = Convert.ToInt32(cboContenedor.SelectedValue),
                            NroContenedor = cboContenedor.Text
                        },
                        Foto = string.Format("{0}\\{1}\\{2}\\{3}", Settings.Default.Photos, cboContrato.Text, cboContenedor.Text, Path.GetFileName(item.Imagen)),
                        oEstado = new EntityLayer.Estado()
                        {
                            IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                            NombreEstado = cboEstado.Text
                        }
                    };

                    //File.Move(item.Imagen, string.Format("{0}{1}{2}", ConfigurationManager.AppSettings["Photos"], cboContrato.Text, cboContenedor.Text));

                    bFoto.Registrar(foto, out Mensaje);
                        //var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
                }
            }
            else
            {
                foto = new EntityLayer.ContratoFoto()
                {
                    oContrato = new EntityLayer.Contrato()
                    {
                        IdContrato = Convert.ToInt32(cboContrato.SelectedValue),
                        NroContratoLote = cboContrato.Text
                    },
                    oContratoContenedor = new EntityLayer.ContratoContenedor()
                    {
                        IdContratoContenedor = Convert.ToInt32(cboContenedor.SelectedValue),
                        NroContenedor = cboContenedor.Text
                    },
                    Foto = string.Format("{0}\\{1}\\{2}\\{3}", Settings.Default.Photos, cboContrato.Text, cboContenedor.Text, Path.GetFileName(rutaarchivo)),
                    oEstado = new EntityLayer.Estado()
                    {
                        IdEstado = Convert.ToInt32(cboEstado.SelectedValue),
                        NombreEstado = cboEstado.Text
                    }
                };
                if (bFoto.Registrar(foto, out Mensaje) > 0)
                {
                    var message = await this.ShowMessageAsync("Consolidados", Mensaje, MessageDialogStyle.Affirmative);
                }
            }
        }
        void MoverFotos()
        {
            foreach (var item in listaFotos) { File.Copy(item.Imagen, string.Format("{0}\\{1}\\{2}\\{3}", Settings.Default.Photos, cboContrato.Text, cboContenedor.Text, Path.GetFileName(item.Imagen))); }
        }
        #endregion
        #region Clases
        public class Fotos
        {
            public string Imagen { get; set; }
        }
        #endregion

        public wndFoto(int IdContratoFoto = 0)
        {
            InitializeComponent();

            CargarContrato();
            CargarContenedor();
            CargarEstado();

            grpMultiple.Visibility = System.Windows.Visibility.Hidden;
            grpSimple.Visibility = System.Windows.Visibility.Visible;

            IdContratoFoto = wndListaFoto.IdFoto;

            if(IdContratoFoto != 0)
            {
                var query = (from f in bFoto.Listar("IdContratoFoto", IdContratoFoto)
                             select f).FirstOrDefault();

                cboContrato.SelectedValue = query.oContrato.IdContrato;
                cboContenedor.SelectedValue = query.oContratoContenedor.IdContratoContenedor;
                imgFoto.Source = new BitmapImage(new Uri(query.Foto));
                cboEstado.SelectedValue = query.oEstado.IdEstado;
            }
        }

        private void BtnExaminar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            bool valor = Convert.ToBoolean(chkMultiple.IsChecked);
            SubirFotos(valor, ofd);
        }

        private void CboContrato_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int IdContrato = Convert.ToInt32(cboContrato.SelectedValue);
            CargarContenedor(IdContrato);
        }

        private void BtnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Guardar();
            DialogResult = true;
            MoverFotos();
            Close();
        }

        private void BtnCancelar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }
    }
}