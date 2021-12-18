using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Amaz_Inc
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class InicioPage : Page
    {
        public static Frame frameData { get; set; }
        public static ArrayList productos { get; set; }
        public InicioPage()
        {
            this.InitializeComponent();
            TendenciasPage.arrayProductos = productos;
            frmInicio.Navigate(typeof(TendenciasPage));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
        }

        private void abrirPane(object sender, RoutedEventArgs e)
        {
            svMenu.IsPaneOpen = !svMenu.IsPaneOpen;
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720)
            {
                svMenu.IsPaneOpen = true;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
            else if (Width >= 360)
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            else
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.Overlay;
            }
        }

        public static ArrayList devolverProductos()
        {
            int i = 0;
            ArrayList productos = new ArrayList();
            productos.Add(new ucProducto(i++, frameData, "Gigabyte GeForce GT 1030", 89.99, 4.5, "https://thumb.pccomponentes.com/w-530-530/articles/16/166292/1.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/16/166292/3.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Logitech G432", 68.99, 5, "https://thumb.pccomponentes.com/w-530-530/articles/20/201439/1.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/20/201439/5.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "MSI GF75 Thin", 1299.99, 4.5, "https://thumb.pccomponentes.com/w-530-530/articles/35/351246/1703-msi-gf75-thin-10ue-017xes-intel-core-i7-10750h-16gb-512gb-ssd-rtx-3060-173.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/35/351246/5775-msi-gf75-thin-10ue-017xes-intel-core-i7-10750h-16gb-512gb-ssd-rtx-3060-173-caracteristicas.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Kingston HyperX Fury Black", 95.00, 5, "https://thumb.pccomponentes.com/w-530-530/articles/23/233960/hyperx-fury-ddr4-9-fan-kit-of-2.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/23/233960/hyperx-fury-ddr4-4-kit-of-2.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Logitech G305", 49.99, 4, "https://thumb.pccomponentes.com/w-530-530/articles/39/391701/1496-logitech-g305-kd-a-raton-gaming-inalambrico.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/39/391701/2572-logitech-g305-kd-a-raton-gaming-inalambrico-comprar.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "PcCom Bronze", 578.14, 4.5, "https://thumb.pccomponentes.com/w-530-530/articles/35/350230/1523-pccom-bronze-intel-core-i5-10400-8gb-1tb-480ssd.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/35/350230/3998-pccom-bronze-intel-core-i5-10400-8gb-1tb-480ssd-mejor-precio.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "MSI X470 Gaming Plus Maz", 94.95, 4.7, "https://thumb.pccomponentes.com/w-530-530/articles/23/238976/sf-nvr6432-4k16p.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/23/238976/91cwzqxrsxl-ac-sl1500.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Newskill Suiko Ivory", 69.95, 5, "https://thumb.pccomponentes.com/w-530-530/articles/24/249972/suiko-ivory.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/24/249972/suiko-ivory2.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "Lenovo IdeaPad 3 15ITL06", 579.00, 4.5, "https://thumb.pccomponentes.com/w-530-530/articles/38/389764/1942-lenovo-ideapad-3-15itl06-intel-core-i5-1135g7-16gb-512gb-ssd-156.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/38/389764/2232-lenovo-ideapad-3-15itl06-intel-core-i5-1135g7-16gb-512gb-ssd-156-comprar.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Nox Hummer H-360", 109.99, 4.5, "https://thumb.pccomponentes.com/w-530-530/articles/30/308251/1473-nox-hummer-h-360-argb-kit-de-refrigeracion-liquida.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/30/308251/6959-nox-hummer-h-360-argb-kit-de-refrigeracion-liquida-opiniones.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Monitor Asus VZ279HE-W", 169.00, 4.5, "https://thumb.pccomponentes.com/w-530-530/articles/15/156537/1.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/15/156537/4.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "Asus F515MA-BR040T", 349.00, 4.1, "https://thumb.pccomponentes.com/w-530-530/articles/35/359955/1571-asus-f515ma-br040t-intel-celeron-n4020-4gb-256gb-ssd-156.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/35/359955/21-asus-f515ma-br040t-intel-celeron-n4020-4gb-256gb-ssd-156-comprar.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Asus GeForce GT 1030", 99.95, 4.1, "https://thumb.pccomponentes.com/w-530-530/articles/30/306332/1233-asus-geforce-gt-1030-2gb-gddr5.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/30/306332/3820-asus-geforce-gt-1030-2gb-gddr5-mejor-precio.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Tempest Conquer Negra", 129.98, 4.2, "https://thumb.pccomponentes.com/w-530-530/articles/23/232311/97691-1.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/23/232311/97691-5.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "HP Pavilion Gaming TG01-1001NS", 669.00, 4.7, "https://thumb.pccomponentes.com/w-530-530/articles/29/295111/hp-pavilion-gaming-tg01-1001ns-intel-core-i5-10400f-8gb-1tb-256gb-ssd-gtx1650.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/29/295111/hp-pavilion-gaming-tg01-1001ns-intel-core-i5-10400f-8gb-1tb-256gb-ssd-gtx1650-comprar.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Team Group Delta White RGB", 121.53, 4.8, "https://thumb.pccomponentes.com/w-530-530/articles/21/217575/1.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/21/217575/2.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Logitech Stereo Speakers Z120", 13.99, 4, "https://thumb.pccomponentes.com/w-530-530/articles/5/50273/logitech-stereo-speakers-z120.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/5/50273/logitech-stereo-speakers-z120-3.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "MSI GE66 Raider 10UE-404XES", 1699.00, 4, "https://thumb.pccomponentes.com/w-530-530/articles/38/387835/1614-msi-ge66-raider-10ue-404xes-intel-core-i7-10870h-32gb-1tb-ssd-rtx-3060-156-36bc26ca-adfb-4342-9fd7-e597a002c71f.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/38/387835/5544-msi-ge66-raider-10ue-404xes-intel-core-i7-10870h-32gb-1tb-ssd-rtx-3060-156-5854fbda-d75d-4e5e-b664-c95ca5d8ebec.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "MSI Z490-A PRO", 159.90, 5, "https://thumb.pccomponentes.com/w-530-530/articles/29/291746/1316-msi-z490-a-pro.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/29/291746/4448-msi-z490-a-pro-especificaciones.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "HP V28 28", 279.00, 4.1, "https://thumb.pccomponentes.com/w-530-530/articles/33/330687/1687-hp-v28-28-led-ultrahd-4k-freesync.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/33/330687/3852-hp-v28-28-led-ultrahd-4k-freesync-mejor-precio.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "MSI Aegis 3 8RC-007EU", 1409.99, 5, "https://thumb.pccomponentes.com/w-530-530/articles/18/183064/1.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/18/183064/5.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Zotac GeForce GTX 1660", 621.66, 4.7, "https://thumb.pccomponentes.com/w-530-530/articles/24/244695/1.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/24/244695/5.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "HP 1000 Ratón USB Negro", 4.99, 3.8, "https://thumb.pccomponentes.com/w-530-530/articles/26/266202/hp-1000-raton-usb-negro.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/26/266202/hp-1000-raton-usb-negro-comprar.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "HP 15S-EQ1019NS", 329.00, 4.2, "https://thumb.pccomponentes.com/w-530-530/articles/28/289415/hp-15s-eq1019ns-amd-athlon-silver-3050u-8gb-256gb-ssd-156.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/28/289415/hp-15s-eq1019ns-amd-athlon-silver-3050u-8gb-256gb-ssd-156-especificaciones.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Corsair Vengeance LPX", 210.00, 4.8, "https://thumb.pccomponentes.com/w-530-530/articles/35/351290/1441-corsair-vengeance-lpx-ddr4-3200mhz-pc4-25600-32gb-2x16gb-cl16.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/35/351290/2302-corsair-vengeance-lpx-ddr4-3200mhz-pc4-25600-32gb-2x16gb-cl16-comprar.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Trust Caro Max", 34.99, 5, "https://thumb.pccomponentes.com/w-530-530/articles/36/365882/1992-trust-caro-max-altavoz-inalambrico-bluetooth-negro.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/36/365882/2629-trust-caro-max-altavoz-inalambrico-bluetooth-negro-comprar.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "Acer Aspire XC-895", 449.01, 4, "https://thumb.pccomponentes.com/w-530-530/articles/32/324787/1582-acer-aspire-xc-895-intel-core-i3-10100-8gb-256gb-ssd-gt730.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/32/324787/4850-acer-aspire-xc-895-intel-core-i3-10100-8gb-256gb-ssd-gt730-especificaciones.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Gigabyte B450M S2H V2", 59.99, 4.2, "https://thumb.pccomponentes.com/w-530-530/articles/34/344971/1145-gigabyte-b450m-s2h-v2.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/34/344971/2803-gigabyte-b450m-s2h-v2-comprar.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Trust GXT 1175 Imperius XL", 239.99, 3.9, "https://thumb.pccomponentes.com/w-530-530/articles/37/374355/153-trust-gxt-1175-imperius-xl-gaming-desk.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/37/374355/2625-trust-gxt-1175-imperius-xl-gaming-desk-comprar.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "MSI Prestige 15 A11SCS-032XES", 1699.00, 4.4, "https://thumb.pccomponentes.com/w-530-530/articles/33/334263/1357-msi-prestige-15-a11scs-032xes-intel-core-i7-1185g7-32gb-1tb-ssd-gtx-1650ti-156.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/33/334263/3745-msi-prestige-15-a11scs-032xes-intel-core-i7-1185g7-32gb-1tb-ssd-gtx-1650ti-156-mejor-precio.jpg", "Ordenador", false));
            productos.Add(new ucProducto(i++, frameData, "Gigabyte B460M DS3H V2", 71.98, 4.4, "https://thumb.pccomponentes.com/w-530-530/articles/37/379133/1580-gigabyte-b460m-ds3h-v2.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/37/379133/2101-gigabyte-b460m-ds3h-v2-comprar.jpg", "Componente", false));
            productos.Add(new ucProducto(i++, frameData, "Trust GXT 450 Blizz", 51.08, 4.2, "https://thumb.pccomponentes.com/w-530-530/articles/24/244449/a32.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/24/244449/a32-5.jpg", "Periferico", false));
            productos.Add(new ucProducto(i++, frameData, "Millenium Machine 1 Mini Rakan", 1548.99, 3, "https://thumb.pccomponentes.com/w-530-530/articles/38/387756/1698-millenium-machine-1-mini-rakan-amd-ryzen-5-5600x-16gb-1tb-240gb-ssd-rtx-3060.jpg", "https://thumb.pccomponentes.com/w-530-530/articles/38/387756/2612-millenium-machine-1-mini-rakan-amd-ryzen-5-5600x-16gb-1tb-240gb-ssd-rtx-3060-comprar.jpg", "Ordenador", false));
            return productos;
        }



        private void irInicio(object sender, PointerRoutedEventArgs e)
        {
            frmInicio.Navigate(typeof(TendenciasPage));
        }

        private void irOrdenadores(object sender, PointerRoutedEventArgs e)
        {
            FiltroPage.arrayProductos = productos;
            FiltroPage.tipoFiltro = "Ordenador";
            frmInicio.Navigate(typeof(FiltroPage));

        }

        private void irPerifericos(object sender, PointerRoutedEventArgs e)
        {
            FiltroPage.arrayProductos = productos;
            FiltroPage.tipoFiltro = "Periferico";
            frmInicio.Navigate(typeof(FiltroPage));
        }

        private void irComponentes(object sender, PointerRoutedEventArgs e)
        {
            FiltroPage.arrayProductos = productos;
            FiltroPage.tipoFiltro = "Componente";
            frmInicio.Navigate(typeof(FiltroPage));
        }
    }
}
