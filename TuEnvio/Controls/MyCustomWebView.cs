using System;
using System.Collections.Generic;
using System.Text;
using TuEnvio.Utils;
using Xamarin.Forms;

namespace TuEnvio.Controls
{
    class MyCustomWebView : WebView
    {

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName.Equals("Renderer")) {
                WidthRequest = UtilsXF.GetScreenWidth();
                HeightRequest = UtilsXF.GetScreenHeight();

            }
        }
    }
}
