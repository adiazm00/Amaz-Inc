using System.Collections;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Amaz_Inc
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class FiltroPage : Page
    {
        public static ArrayList arrayProductos { get; set; }
        public static string tipoFiltro { get; set; }
        public FiltroPage()
        {
            this.InitializeComponent();
            if(tipoFiltro.Equals("Ordenador")) this.tbFiltro.Text = "Ordenadores";
            else if (tipoFiltro.Equals("Periferico")) this.tbFiltro.Text = "Periféricos";
            else if (tipoFiltro.Equals("Componente")) this.tbFiltro.Text = "Componentes";
            filtrar(tipoFiltro);
        }

        private void filtrar(string tipo)
        {
            foreach (ucProducto elemento in arrayProductos)
            {
                if (elemento.tipoProd.Equals(tipo)) {
                    ucProducto ucProdAux = new ucProducto(elemento.id, elemento.frmMain, elemento.nombreProd, elemento.precioProd, elemento.valoracionProd, elemento.enlaceFotoProd, elemento.enlaceFotoProd2, elemento.tipoProd, elemento.fav);
                    ucProdAux.ponerFav();
                    ucProdAux.arrayProductos = arrayProductos;
                    gvFiltro.Items.Add(ucProdAux);
                }
            }
        }
    }
}
