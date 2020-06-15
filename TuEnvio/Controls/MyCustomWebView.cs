using System;
using System.Collections.Generic;
using System.Text;
using TuEnvio.Utils;
using TuEnvio.Views;
using Xamarin.Forms;

namespace TuEnvio.Controls
{
    public class MyCustomWebView : WebView
    {
        internal UrlWebViewSource currentSource { get; set; }

        public string Title{ get; set; }

        public double AdsHeight { get; set; }

        public FloatingActionButton floatingActionButton { get; set; }

        protected override async void OnPropertyChanged(string propertyName)
        {
            if (propertyName.Equals("Source")) {
                WidthRequest = UtilsXF.GetScreenWidth();
                HeightRequest = UtilsXF.GetScreenHeight() - AdsHeight;
            }
        }
    }
}
