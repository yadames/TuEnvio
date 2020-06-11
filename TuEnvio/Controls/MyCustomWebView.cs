using System;
using System.Collections.Generic;
using System.Text;
using TuEnvio.Utils;
using Xamarin.Forms;

namespace TuEnvio.Controls
{
    public class MyCustomWebView : WebView
    {

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName.Equals("Source")) {
                WidthRequest = UtilsXF.GetScreenWidth();
                HeightRequest = UtilsXF.GetScreenHeight();
            }
        }
    }
}
