using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Amaz_Inc
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetallesProducto : Page
    {
        public static Frame frameData { get; set; }
        public static string precio { get; set; }
        public static string nombre { get; set; }
        public static double valoracion { get; set; }
        public static string enlaceFoto { get; set; }
        public static string enlaceFoto2 { get; set; }
        public DetallesProducto()
        {
            this.InitializeComponent();
            this.tbNombreProducto.Text = nombre;
            this.tbPrecio.Text = "Precio: "+precio+" €";
            this.rcValoracion.Value = valoracion;
            this.imProducto1.Source = new BitmapImage(new Uri(@"" + enlaceFoto));
            this.imProducto2.Source = new BitmapImage(new Uri(@"" + enlaceFoto2));
            this.tbDescripcionTexto.Text = "En este espacio debería aparecer una breve descripción del producto en cuestión.";
        }

        private void anadirCesta(object sender, RoutedEventArgs e)
        {
            ucProductoCesta ucProdCesta = new ucProductoCesta(enlaceFoto, nombre, precio);
            CestaPage.anadirProducto(ucProdCesta);
        }
    }
}
