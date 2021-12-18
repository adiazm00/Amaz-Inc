using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections;
using Microsoft.Toolkit.Uwp.Notifications;


// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Amaz_Inc
{
    public sealed partial class ucProducto : UserControl
    {
        public ArrayList arrayProductos { get; set; }
        public int id { get; set; }
        public Frame frmMain;
        public string nombreProd { get; set; }
        public double precioProd { get; set; }
        public double valoracionProd { get; set; }
        public string enlaceFotoProd { get; set; }
        public string enlaceFotoProd2 { get; set; }
        public string tipoProd { get; set; }
        public bool fav { get; set; }
        public ucProducto(int id,Frame frameAux, string nombre, double precio, double valoracion, string enlaceFoto, string enlaceFoto2, string tipo, bool fav)
        {
            this.id = id;
            frmMain = frameAux;
            this.InitializeComponent();
            this.tbNombreProducto.Text = nombre;
            this.tbPrecio.Text = precio.ToString() + " €";
            this.rcValoracion.Value = valoracion;
            this.imProducto.Source = new BitmapImage(new Uri(@"" + enlaceFoto));
            this.tbEnlaceImagen.Text = enlaceFoto;
            this.tbEnlaceImagen2.Text = enlaceFoto2;
            nombreProd = nombre;
            precioProd = precio;
            valoracionProd = valoracion;
            enlaceFotoProd = enlaceFoto;
            enlaceFotoProd2 = enlaceFoto2;
            tipoProd = tipo;
            this.fav = fav;
            ponerFav();
        }

        private void cargarDetalles(object sender, PointerRoutedEventArgs e)
        {
            DetallesProducto.frameData = frmMain;
            DetallesProducto.enlaceFoto = tbEnlaceImagen.Text;
            DetallesProducto.enlaceFoto2 = tbEnlaceImagen2.Text;
            DetallesProducto.precio = tbPrecio.Text.Split(" ")[0];
            DetallesProducto.valoracion = rcValoracion.Value;
            DetallesProducto.nombre = tbNombreProducto.Text;
            frmMain.Navigate(typeof(DetallesProducto));
        }

        public void ponerFav()
        {
            if (fav)
            {
                this.imFav.Source = new BitmapImage(new Uri(@"" + "https://images-ext-1.discordapp.net/external/aGMWBYDOFbCa2imiNTrKT9nmzBTBtCnvEfsQ1BgE8YU/https/image.flaticon.com/icons/png/128/833/833472.png"));
            }
            else
            {
                this.imFav.Source = new BitmapImage(new Uri(@"" + "https://images-ext-1.discordapp.net/external/TX9KLuJMp-izXOgKysdGBZQbOLAbjMHEd3st4BJ7pio/https/image.flaticon.com/icons/png/128/535/535285.png"));
            }
        }

        private void cambiarFav(object sender, PointerRoutedEventArgs e)
        {
            fav = !fav;
            foreach (ucProducto elemento in arrayProductos)
            {
                if (id == elemento.id)
                {
                    elemento.fav = fav;
                    break;
                }
            }
            FiltroPage.arrayProductos = arrayProductos;
            TendenciasPage.arrayProductos = arrayProductos;
            if (fav)
            {
                this.imFav.Source = new BitmapImage(new Uri(@"" + "https://images-ext-1.discordapp.net/external/aGMWBYDOFbCa2imiNTrKT9nmzBTBtCnvEfsQ1BgE8YU/https/image.flaticon.com/icons/png/128/833/833472.png"));
                new ToastContentBuilder()
                .AddArgument("action", "Añadido a Favoritos")
                .AddArgument("conversationId", 9813)
                .AddText("Se ha añadido a Favoritos el producto: " + nombreProd)
                .AddText("Puede consultar los detalles en Amaz Inc")
                .AddAppLogoOverride(new Uri(enlaceFotoProd), ToastGenericAppLogoCrop.Circle)
                .Show();
            }
            else
            {
                this.imFav.Source = new BitmapImage(new Uri(@"" + "https://images-ext-1.discordapp.net/external/TX9KLuJMp-izXOgKysdGBZQbOLAbjMHEd3st4BJ7pio/https/image.flaticon.com/icons/png/128/535/535285.png"));
            }
        }
    }
}