using System.Collections;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Amaz_Inc
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class TendenciasPage : Page
    {
        public static ArrayList arrayProductos { get; set; }
        public TendenciasPage()
        {
            this.InitializeComponent();
            anadirDestacados();
            anadirMasVendidos();
            anadirPopulares();
        }

        private void anadirDestacados()
        {
            int i = 0;
            foreach (ucProducto elemento in arrayProductos)
            {
                ucProducto ucProdAux = new ucProducto(elemento.id, elemento.frmMain, elemento.nombreProd, elemento.precioProd, elemento.valoracionProd, elemento.enlaceFotoProd, elemento.enlaceFotoProd2, elemento.tipoProd, elemento.fav);
                ucProdAux.ponerFav();
                ucProdAux.arrayProductos = arrayProductos;
                spDestacados.Children.Add(ucProdAux);
                i++;
                if (i >= 10) break;
            }
        }
        private void anadirMasVendidos()
        {
            int i = 0;
            foreach (ucProducto elemento in arrayProductos)
            {
                ucProducto ucProdAux = new ucProducto(elemento.id, elemento.frmMain, elemento.nombreProd, elemento.precioProd, elemento.valoracionProd, elemento.enlaceFotoProd, elemento.enlaceFotoProd2, elemento.tipoProd, elemento.fav);
                ucProdAux.ponerFav();
                ucProdAux.arrayProductos = arrayProductos;
                i++;
                if (i >= 10 && i < 20) spMasVendidos.Children.Add(ucProdAux);
            }
        }
        private void anadirPopulares()
        {
            int i = 0;
            foreach (ucProducto elemento in arrayProductos)
            {
                ucProducto ucProdAux = new ucProducto(elemento.id, elemento.frmMain, elemento.nombreProd, elemento.precioProd, elemento.valoracionProd, elemento.enlaceFotoProd, elemento.enlaceFotoProd2, elemento.tipoProd, elemento.fav);
                ucProdAux.ponerFav();
                ucProdAux.arrayProductos = arrayProductos;
                i++;
                if (i >= 20) spPopulares.Children.Add(ucProdAux);
                else if (i >= 30) break;
            }
        }
    }
}
