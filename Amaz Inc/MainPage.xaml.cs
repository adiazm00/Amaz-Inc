using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections;
using System.Linq;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Amaz_Inc
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Boolean inicioSesion { get; set; }
        static ThreadPoolTimer windowResizeTimer;
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            InicioPage.frameData = this.frmMain;
            InicioPage.productos = InicioPage.devolverProductos();
            frmMain.Navigate(typeof(InicioPage));
            SystemNavigationManager.GetForCurrentView().BackRequested += irAtras;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Bienvenido a Amaz Inc.",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Pincha para conocer nuestros Productos",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Bienvenido a Amaz Inc.",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Pincha para conocer nuestros Productos",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Amaz Inc.",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Comprueba nuestras ofertas",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Visita nuestros productos",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    }//,
                }
            };
            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);
        }

        private void irAtras(object sender, BackRequestedEventArgs e)
        {
            if (frmMain.BackStack.Any()) frmMain.GoBack();
        }

        private void cargarInicio(object sender, PointerRoutedEventArgs e)
        {
            InicioPage.frameData = this.frmMain;
            frmMain.Navigate(typeof(InicioPage));
        }

        private void cargarCesta(object sender, PointerRoutedEventArgs e)
        {
            ArrayList arrayProductosCesta = CestaPage.devolverArray();
            ArrayList arrayProductosCestaAux = new ArrayList();
            foreach (ucProductoCesta elemento in arrayProductosCesta)
            {
                ucProductoCesta ucProdAux = new ucProductoCesta(elemento.enlaceProd, elemento.nombreProd, elemento.precioProd);
                arrayProductosCestaAux.Add(ucProdAux);
            }
            CestaPage.productosCesta = arrayProductosCestaAux;
            frmMain.Navigate(typeof(CestaPage));
        }

        private void cargarCuenta(object sender, PointerRoutedEventArgs e)
        {
            frmMain.Navigate(typeof(CuentaPage));
        }

        private void cargarLogin(object sender, PointerRoutedEventArgs e)
        {
            if(tbIniciarSesion.Text.Equals("Iniciar sesión"))
            {
                inicioSesion = true;
                LoginPage.frameData = this.frmMain;
                LoginPage.tbCambiar = this.tbIniciarSesion;
                frmMain.Navigate(typeof(LoginPage));
            }
            else
            {
                inicioSesion = false;
                CuentaPage.frameData = this.frmMain;
                CuentaPage.tbCambiar = this.tbIniciarSesion;
                frmMain.Navigate(typeof(CuentaPage));
            }
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720)
            {
                imCesta.Height = 50;
                imCesta.Width = 50;
                imIniciarSesion.Height = 50;
                imIniciarSesion.Width = 50;
                imCesta.Margin = new Thickness(10, 11, 10, 39);
                imIniciarSesion.Margin = new Thickness(10, 11, 10, 39);
                tbCesta.Visibility = Visibility.Visible;
                tbIniciarSesion.Visibility = Visibility.Visible;
            }
            else if (Width >= 360)
            {
                imCesta.Height = 40;
                imCesta.Width = 40;
                imIniciarSesion.Height = 40;
                imIniciarSesion.Width = 40;
                imCesta.Margin = new Thickness(10, 20, 10, 20);
                imIniciarSesion.Margin = new Thickness(10, 20, 10, 20);
                tbCesta.Visibility = Visibility.Collapsed;
                tbIniciarSesion.Visibility = Visibility.Collapsed;
            }
        }


    }
}
