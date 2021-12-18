using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Amaz_Inc
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CuentaPage : Page
    {
        public static Frame frameData { get; set; }
        public static TextBlock tbCambiar { get; set; }
        public static string nombre { get; set; }
        public static string correo { get; set; }
        public CuentaPage()
        {
            this.InitializeComponent();
            tbNombre.Text = nombre;
            tbCorreo.Text = correo;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
        }

        private void cerrarSesion(object sender, RoutedEventArgs e)
        {
            tbCambiar.Text = "Iniciar sesión";
            frameData.Navigate(typeof(LoginPage));
        }

        private void MainPage_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            var width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (width >= 800)
            {
                RelativePanel.SetRightOf(tbMisPagos, tbMisDirecciones);
                RelativePanel.SetBelow(tbMisPagos, null);

                RelativePanel.SetRightOf(tbMisPedidos, tbMisPromociones);
                RelativePanel.SetBelow(tbMisPedidos, tbMisPagos);
            }
            else
            {
                RelativePanel.SetRightOf(tbMisPagos, null);
                RelativePanel.SetBelow(tbMisPagos, tbCambiarContraseña);

                RelativePanel.SetRightOf(tbMisPedidos, tbMisPagos);
                RelativePanel.SetBelow(tbMisPedidos, tbMisPromociones);
            }
        }
    }
}
