using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Pages;
using TuEnvio.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingActionButton : ContentView
    {
        public FloatingActionButton()
        {
            InitializeComponent();
        }

        //private async void search_click(object sender, EventArgs e) 
        //{

        //    HomeDetails tabbedPage = App.HostApp.GetRootPage();

        //    await tabbedPage.DoActionAsync(2, search_entry.Text);

        //    Log.Track("Search click");

        //    //(App.HostApp.MainPage as HomeMaster);
        //}

        //private void share_click(object sender, EventArgs e)
        //{
        //    HomeDetails tabbedPage = App.HostApp.GetRootPage();
        //    tabbedPage.ShareLinkAsync();
        //    Log.Track("Share click");
        //}

        //private async void refresh_click(object sender, EventArgs e) {
        //    HomeDetails tabbedPage = App.HostApp.GetRootPage();
        //    await tabbedPage.DoActionAsync(1);
        //    Log.Track("Refresh click");
        //}

        //private void open_click(object sender, EventArgs e)
        //{
        //    Log.Track("Open transfermovil click");
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        Xamarin.Forms.Device.OpenUri(new Uri("transfermovil://tm_compra_en_linea/action?id_transaccion=N4C-D8875083124933&importe=2.270000&moneda=CUC&numero_proveedor=30072"));
        //    });
        //}


    }
}