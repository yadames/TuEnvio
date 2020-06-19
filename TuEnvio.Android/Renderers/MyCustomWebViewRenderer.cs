using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TuEnvio.Controls;
using TuEnvio.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomWebView), typeof(MyCustomWebViewRenderer))]

namespace TuEnvio.Droid.Renderers
{
    public class MyCustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.Settings.JavaScriptEnabled = true;
                Control.Settings.CacheMode = Android.Webkit.CacheModes.Normal;
            }
        }
    }
}