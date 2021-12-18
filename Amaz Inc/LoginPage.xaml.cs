using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Amaz_Inc
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public static Frame frameData { get; set; }
        public static TextBlock tbCambiar { get; set; }
        public LoginPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
        }

        private async void iniciarSesion(object sender, RoutedEventArgs e)
        {
            if (tbUsuario.Text.ToLower().Equals("claudio.diaz") && tbContrasena.Password.ToString().Equals("claudio"))
            {
                tbCambiar.Text = "Mi cuenta";
                CuentaPage.tbCambiar = tbCambiar;
                CuentaPage.frameData = frameData;
                CuentaPage.nombre = "Claudio Díaz Ávalos";
                CuentaPage.correo = "claudio.diaz19@alu.uclm.es";
                frameData.Navigate(typeof(CuentaPage));
            }
            else if (tbUsuario.Text.ToLower().Equals("andres.diaz") && tbContrasena.Password.ToString().Equals("andres"))
            {
                tbCambiar.Text = "Mi cuenta";
                CuentaPage.tbCambiar = tbCambiar;
                CuentaPage.frameData = frameData;
                CuentaPage.nombre = "Andrés Chaparro Díaz";
                CuentaPage.correo = "andres.chaparro19@alu.uclm.es";
                frameData.Navigate(typeof(CuentaPage));
            }
            else if (tbUsuario.Text.ToLower().Equals("alberto.diaz") && tbContrasena.Password.ToString().Equals("alberto"))
            {
                tbCambiar.Text = "Mi cuenta";
                CuentaPage.tbCambiar = tbCambiar;
                CuentaPage.frameData = frameData;
                CuentaPage.nombre = "Alberto Díaz Martín";
                CuentaPage.correo = "alberto.diaz19@alu.uclm.es";
                frameData.Navigate(typeof(CuentaPage));
            }
            else if(tbUsuario.Text.Length == 0 | tbContrasena.Password.Length == 0)
            {
                var dialog = new MessageDialog("Debe rellenar los apartados anteriores");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Las credenciales introducidas no son válidas");
                await dialog.ShowAsync();
            }
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720)
            {
                lblUsuario.FontSize = 35;
                lblContrasena.FontSize = 35;
                tbUsuario.Width = 400;
                tbUsuario.Height = 55;
                tbUsuario.FontSize = 24;
                tbContrasena.Width = 400;
                tbContrasena.Height = 55;
                tbContrasena.FontSize = 24;
                btnIniciarSesion.FontSize = 20;
                btnIniciarSesion.Width = 150;
                btnIniciarSesion.Height = 50;
                imLogo2.MaxHeight = 350;
                imLogo2.MaxWidth = 350;
            }
            else if (Width >= 360)
            {
                lblUsuario.FontSize = 20;
                lblContrasena.FontSize = 20;
                tbUsuario.Width = 170;
                tbUsuario.Height = 35;
                tbUsuario.FontSize = 20;
                tbContrasena.Width = 170;
                tbContrasena.Height = 35;
                tbContrasena.FontSize = 20;
                btnIniciarSesion.FontSize = 14;
                btnIniciarSesion.MinWidth = 110;
                btnIniciarSesion.MinHeight = 30;
            }
        }
    }
}
