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

        public MainTab()
        {
            InitializeComponent();
        }

        private async Task<string> GetTitle()
        {
            return await WebView.EvaluateJavaScriptAsync("$(document).find('title').text();");
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
            string title = await GetTitle();
            string[] line = title.Split(new[] { "\\r\\n", "\\r", "\\n" }, StringSplitOptions.None);
            string formatTitle = UtilsXF.RemoveSpecialCharacters(line[4]).Trim();

            _ = ShareUtils.ShareText(formatTitle, ((UrlWebViewSource)WebView.Source).Url);
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            try {

                AbsoluteLayout absoluteLayout = (CurrentPage as ContentPage).Content as AbsoluteLayout;

                WebView = (absoluteLayout.Children[0] as StackLayout).Children[0] as MyCustomWebView;
                floatingActionButton = absoluteLayout.Children[2] as FloatingActionButton;

                WebView.Focused -= WebView_Focused;
                WebView.Focused += WebView_Focused;

            }
            catch (Exception e) {}
        }

        private void WebView_Focused(object sender, FocusEventArgs e)
        {
            if (floatingActionButton.IsVisible)
                floatingActionButton.IsVisible = false;
        }

        public void RefreshAllTabs(string url) 
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

        public void UpdateWebView(StackLayout container, UrlWebViewSource newURL) {
            container.Children.Clear();
            MyCustomWebView webView = new MyCustomWebView
            {
                Source = newURL
            };

            container.Children.Add(webView);
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
    }
}