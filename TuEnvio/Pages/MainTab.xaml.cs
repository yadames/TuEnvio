using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Controls;
using TuEnvio.Utils;
using TuEnvio.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTab : TabbedPage
    {
        public const string CARLOSIII = "carlos3";
        public const string CUATRO_CAMINOS = "4caminos";
        public const string PEDREGAL = "tvpedregal";
        public const string TIPICA = "tipicaboyeros";

        public const string URL_DOMAIN = "https://www.tuenvio.cu/";
        public const string URL_SEARCH = "/Search.aspx?keywords=";

        public string[] SHOP = new string[] { CARLOSIII, CUATRO_CAMINOS, PEDREGAL, TIPICA };

        public MyCustomWebView WebView { get; set; }
        public FloatingActionButton floatingActionButton { get; set; }

        public double AdsHeight { get; set; }

        public MainTab()
        {
            InitializeComponent();
        }

        private async Task<string> GetTitle()
        {
            //return await WebView.EvaluateJavaScriptAsync("$(document).find('title').text();");
            return await WebView.EvaluateJavaScriptAsync("document.title;");
        }

        private void refresh_Clicked(object sender, EventArgs e)
        {
            WebView.WidthRequest = UtilsXF.GetScreenWidth();
            WebView.HeightRequest = UtilsXF.GetScreenHeight();
            WebView.Reload();
        }

        private void menu_Clicked(object sender, EventArgs e) 
        {
            floatingActionButton.IsVisible = !floatingActionButton.IsVisible;
        }

        public async void ShareLinkAsync()
        {
            try
            {
                AbsoluteLayout absoluteLayout = (CurrentPage as ContentPage).Content as AbsoluteLayout;

                MyCustomWebView currentWebView = (absoluteLayout.Children[0] as StackLayout).Children[0] as MyCustomWebView;

                string title = await currentWebView.EvaluateJavaScriptAsync("document.title;");
                //string[] line = title.Split(new[] { "\\r\\n", "\\r", "\\n" }, StringSplitOptions.None);
                string lite = UtilsXF.RemoveSpecialCharacters(title.Substring(title.LastIndexOf(" - ")));
                //string formatTitle = UtilsXF.RemoveSpecialCharacters(line[4]).Trim();

                _ = ShareUtils.ShareText(lite, ((UrlWebViewSource)WebView.Source).Url);
            }
            catch (Exception)
            {
                _ = ShareUtils.ShareText("", ((UrlWebViewSource)WebView.Source).Url);
            }
            
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            try {

                AbsoluteLayout absoluteLayout = (CurrentPage as ContentPage).Content as AbsoluteLayout;

                WebView = (absoluteLayout.Children[0] as StackLayout).Children[0] as MyCustomWebView;
                floatingActionButton = absoluteLayout.Children[2] as FloatingActionButton;

                //WebView.floatingActionButton = floatingActionButton;

                WebView.Focused -= WebView_Focused;
                WebView.Focused += WebView_Focused;

                WebView.Navigating -= WebView_Navigating;
                WebView.Navigating += WebView_Navigating;

            }
            catch (Exception e) {}
        }

        private void WebView_Focused(object sender, FocusEventArgs e)
        {
            if (floatingActionButton.IsVisible)
                floatingActionButton.IsVisible = false;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.StartsWith("transfermovil://"))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Uri uri = new Uri(e.Url);
                    Xamarin.Forms.Device.OpenUri(uri);
                });
                e.Cancel = true;
            }
        }

        public void RefreshAll()
        {
            int i = 0;
            foreach (ContentPage page in Children)
            {
                MyCustomWebView webview = ((page.Content as AbsoluteLayout).Children[0] as StackLayout).Children[0] as MyCustomWebView;

                webview.Reload();
                i++;
            }
        }

        public void RefreshAllTabs(string url = null) 
        {
            int i = 0;
            foreach (ContentPage page in Children) { 
                MyCustomWebView webview = ((page.Content as AbsoluteLayout).Children[0] as StackLayout).Children[0] as MyCustomWebView;

                string newUrl = url.Replace(CARLOSIII, SHOP[i]).Replace(CUATRO_CAMINOS, SHOP[i]).Replace(PEDREGAL, SHOP[i]).Replace(TIPICA, SHOP[i]);
                webview.Source = newUrl;
                i++;
            }
        }


        public void FindInAllTabs(string query)
        {
            int i = 0;
            foreach (ContentPage page in Children)
            {
                MyCustomWebView webview = ((page.Content as AbsoluteLayout).Children[0] as StackLayout).Children[0] as MyCustomWebView;

                string newUrl = URL_DOMAIN + SHOP[i] + URL_SEARCH + '"' + query + '"';

                UpdateWebView(webview.Parent as StackLayout, new UrlWebViewSource { Url = newUrl });
                WebView = webview;
                i++;
            }
        }

        public void OpenUrl(string url) 
        {
            if (url.Contains(CARLOSIII)) 
            {
                NavigateToTabIndex(0);
            }
            else if (url.Contains(CUATRO_CAMINOS))
            {
                NavigateToTabIndex(1);
            }
            else if (url.Contains(PEDREGAL))
            {
                NavigateToTabIndex(2);
            }
            else if (url.Contains(TIPICA))
            {
                NavigateToTabIndex(3);
            }

            WebView.Source = url;
        }

        public void NavigateToTabIndex(int index)
        {
            CurrentPage = Children[index];
        }

        public MyCustomWebView UpdateWebView(StackLayout container, UrlWebViewSource newURL) {

            MyCustomWebView webView = new MyCustomWebView
            {
                Source = newURL,
                AdsHeight = AdsHeight,
                Title = WebView.Title
            };
            container.Children.Clear();
            container.Children.Add(webView);
            container.Children.Add(new AdmobControl() { 
                AdUnitId = "ca-app-pub-2807998494224675/5950558114",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = 0
            });

            return webView;
        }

        protected override bool OnBackButtonPressed()
        {
            if (WebView.CanGoBack)
            {
                WebView.GoBack();
                return true;
            }
            else {
                return base.OnBackButtonPressed();
            }
        }

        public static void AdsLoaded(double height) {
            MainTab tabbedPage = App.HostApp.MainPage as MainTab;
            tabbedPage.AdsHeight = height + 50;
            tabbedPage.RefreshWebViewSize();
        }

        public void RefreshWebViewSize()
        {
            int i = 0;
            foreach (ContentPage page in Children)
            {
                MyCustomWebView webview = ((page.Content as AbsoluteLayout).Children[0] as StackLayout).Children[0] as MyCustomWebView;
                webview.AdsHeight = AdsHeight;
                i++;
            }
        }

    }
}