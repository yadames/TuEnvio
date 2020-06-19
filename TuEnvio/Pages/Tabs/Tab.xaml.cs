using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Controls;
using TuEnvio.Model;
using TuEnvio.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tab : ContentPage
    {
        public Tab()
        {
            InitializeComponent();
            
        }


        public Tab(Tienda tienda)
        {
            Title = tienda.Nombre;

            MyCustomWebView webView = new MyCustomWebView()
            {
                Source = tienda.URL,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = 0
            };

            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = GridLength.Auto }
                },
                RowSpacing = 0,
                ColumnSpacing = 0,
                Padding = 0, Margin = 0
            };

            grid.Children.Add(webView, 0, 0);
            Content = grid;
        }

    }
}