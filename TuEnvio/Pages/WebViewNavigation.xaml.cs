using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Controls;
using TuEnvio.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewNavigation : ContentPage
    {
        public WebViewNavigation()
        {
            InitializeComponent();
        }

        public WebViewNavigation(string source) {
            InitializeComponent();

            Title = "Enlace externo";
            grid.Children.Add(new WebView()
            {
                Source = source
            }, 0, 0);

            if (!(grid.Children.Last() is AdmobControl))
            {
                AdmobControl admob = new AdmobControl()
                {
                    AdUnitId = Const.GetRandomAds(),
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 0,
                    HeightRequest = 90
                };
                grid.Children.Add(admob, 0, 1);
            }


            Log.Track(Const.OPEN_HELP);
        }
    }
}