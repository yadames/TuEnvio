using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingActionButton : ContentView
    {
        //public const string URL = https://www.tuenvio.cu/carlos3/Search.aspx?keywords=%22papel%22&depPid=0;

        public FloatingActionButton()
        {
            InitializeComponent();
        }

        private async void search_click(object sender, EventArgs e) 
        {

            MainTab tabbedPage = App.HostApp.MainPage as MainTab;

            await tabbedPage.DoActionAsync(2, search_entry.Text);

            IsVisible = false;
        }

        private void share_click(object sender, EventArgs e)
        {
            MainTab tabbedPage = App.HostApp.MainPage as MainTab;
            tabbedPage.ShareLinkAsync();
        }

        private async void refresh_click(object sender, EventArgs e) {
            MainTab tabbedPage = App.HostApp.MainPage as MainTab;
            await tabbedPage.DoActionAsync(1);
        }

        private void open_click(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Xamarin.Forms.Device.OpenUri(new Uri("transfermovil://tm_compra_en_linea/action?id_transaccion=N4C-D8875083124933&importe=2.270000&moneda=CUC&numero_proveedor=30072"));
            });
        }
    }
}