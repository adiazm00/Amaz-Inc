using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Amaz_Inc
{
    public sealed partial class ucProductoCesta : UserControl
    {
        public string nombreProd { get; set; }
        public string precioProd { get; set; }
        public string enlaceProd { get; set; }
        public ucProductoCesta(string enlaceFoto, string nombre, string precio)
        {
            this.InitializeComponent();
            this.tbNombreProducto.Text = nombre;
            this.tbPecioProducto.Text = precio.ToString() + " EUR";
            this.imProducto.Source = new BitmapImage(new Uri(@"" + enlaceFoto));
            nombreProd = nombre;
            precioProd = precio;
            enlaceProd = enlaceFoto;
        }

        private void eliminarProducto(object sender, PointerRoutedEventArgs e)
        {
            CestaPage.eliminarProducto(this);
        }
    }
}
