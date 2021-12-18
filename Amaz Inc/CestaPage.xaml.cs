using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Amaz_Inc
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CestaPage : Page
    {
        public static int numeroProductos = 0;
        public static TextBlock numProductos = new TextBlock();

        public static double precioTotal = 00.00;
        public static TextBlock precTotal = new TextBlock();

        public static StackPanel spProductosAux = new StackPanel();
        public static ArrayList productosCesta = new ArrayList();

        public CestaPage()
        {
            this.InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
            tbNumProductos.Text = numeroProductos + " productos seleccionados";
            numProductos = this.tbNumProductos;
            precioTotal = (Math.Round(precioTotal * 1000) / 1000);
            precioTotal = (Math.Truncate(precioTotal * 100) / 100);
            tbTotal.Text = "Total: " + precioTotal + " EUR";
            precTotal = this.tbTotal;
            foreach (ucProductoCesta elemento in productosCesta)
            {
                spProductos.Children.Add(elemento);
            }
            spProductosAux = this.spProductos;
        }

        public static void anadirProducto(ucProductoCesta ucProdCestaAux)
        {
            numeroProductos += 1;
            numProductos.Text = numeroProductos + " productos seleccionados";
            precioTotal += double.Parse(ucProdCestaAux.precioProd);
            precTotal.Text = "Total: " + precioTotal + " EUR";
            productosCesta.Add(ucProdCestaAux);
        }

        public static void eliminarProducto(ucProductoCesta ucProdCestaAux)
        {
            numeroProductos -= 1;
            numProductos.Text = numeroProductos + " productos seleccionados";
            productosCesta.Remove(ucProdCestaAux);
            spProductosAux.Children.Remove(ucProdCestaAux);
            precioTotal -= double.Parse(ucProdCestaAux.precioProd);
            precioTotal = (Math.Round(precioTotal * 1000) / 1000);
            precioTotal = (Math.Truncate(precioTotal * 100) / 100);
            if (precioTotal < 0.001) precioTotal = 0;
            precTotal.Text = "Total: " + precioTotal + " EUR";
        }

        public static ArrayList devolverArray()
        {
            return productosCesta;
        }

        private void vaciarCesta(object sender, RoutedEventArgs e)
        {
            spProductos.Children.Clear();
            productosCesta.Clear();
            numeroProductos = 0;
            tbNumProductos.Text = numeroProductos + " productos seleccionados";
            precioTotal = 0.00;
            precTotal.Text = "Total: " + precioTotal + " EUR";
        }

        private async void tramitarPedido(object sender, RoutedEventArgs e)
        {
            if (MainPage.inicioSesion)
            {
                if (numeroProductos > 0)
                {
                    new ToastContentBuilder()
                    .AddArgument("action", "Pedido tramitado")
                    .AddArgument("conversationId", 9813)
                    .AddText("Pedido realizado correctamente")
                    .AddText("Puede consultar los detalles de su pedido en Amaz Inc")
                    .AddAppLogoOverride(new Uri("https://image.flaticon.com/icons/png/256/1554/1554561.png"), ToastGenericAppLogoCrop.Circle)
                    .Show();
                    spProductos.Children.Clear();
                    productosCesta.Clear();
                    numeroProductos = 0;
                    tbNumProductos.Text = numeroProductos + " productos seleccionados";
                    precioTotal = 0.00;
                    precTotal.Text = "Total: " + precioTotal + " EUR";
                }
                else
                {
                    var dialog = new MessageDialog("Debe añadir algún productos antes");
                    await dialog.ShowAsync();
                }
            }
            else
            {
                var dialog = new MessageDialog("Debe iniciar sesión antes");
                await dialog.ShowAsync();
            }
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720)
            {
                btnVaciarCesta.Width = 190;
                btnVaciarCesta.Height = 50;
                btnVaciarCesta.FontSize = 24;
                btnRealizarPedido.Width = 190;
                btnRealizarPedido.Height = 50;
                btnRealizarPedido.FontSize = 24;
                tbNumProductos.FontSize = 22;
                tbTotal.FontSize = 22;
            }
            else if (Width >= 360)
            {
                btnVaciarCesta.Width = 150;
                btnVaciarCesta.Height = 40;
                btnVaciarCesta.FontSize = 18;
                btnRealizarPedido.Width = 150;
                btnRealizarPedido.Height = 40;
                btnRealizarPedido.FontSize = 18;
                tbNumProductos.FontSize = 20;
                tbTotal.FontSize = 20;
            }
        }
    }
}
