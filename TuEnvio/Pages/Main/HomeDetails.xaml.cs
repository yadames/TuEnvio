using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Controls;
using TuEnvio.Model;
using TuEnvio.Utils;
using TuEnvio.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetails : TabbedPage
    {

        public MyCustomWebView WebView { get; set; }

        public HomeDetails()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            this.Children.Clear();
            List<Tienda> tiendas = App.HostApp.AppModel.GetSelected();
            if (tiendas.Any())
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    foreach (Tienda tienda in tiendas)
                    {
                        this.Children.Add(new Tab(tienda));
                        Task.Delay(100).Wait();
                    }
                });
            }
            else
            {
                this.Children.Add(new Tab());
            }
        }

        private Grid GetCurrentGrid()
        {
            return (CurrentPage as ContentPage).Content as Grid;
        }

        private MyCustomWebView GetCurrentWebView()
        {
            Grid grid = GetCurrentGrid();
            return grid?.Children[0] as MyCustomWebView;
        }

        public async void ShareLinkAsync()
        {
            MyCustomWebView currentWebView = GetCurrentWebView();
            try
            {
                if (currentWebView != null)
                {
                    string title = await currentWebView.EvaluateJavaScriptAsync("document.title;");

                    string lite = !title.Contains("Mantenimiento") ? UtilsXF.RemoveSpecialCharacters(title.Substring(title.LastIndexOf(" - "))) : title;

                    _ = ShareUtils.ShareText(lite, ((UrlWebViewSource)WebView.Source).Url);

                }
            }
            catch (Exception)
            {
                if (currentWebView != null)
                {
                    _ = ShareUtils.ShareText("", ((UrlWebViewSource)WebView.Source).Url);
                }
            }

        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            try
            {
                if (CurrentPage != null)
                {
                    WebView = GetCurrentWebView();
                    AddAds();
                }

            }
            catch (Exception e) { }
        }

        private void AddAds()
        {
            Grid currentGrid = GetCurrentGrid();

            if (currentGrid != null && !(currentGrid.Children.Last() is AdmobControl))
            {
                AdmobControl admob = new AdmobControl()
                {
                    AdUnitId = Const.GetRandomAds(),
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 0,
                    HeightRequest = 90
                };
                currentGrid.Children.Add(admob, 0, 1);
            }
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.StartsWith("transfermovil://"))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Uri uri = new Uri(e.Url);
                    Xamarin.Forms.Device.OpenUri(uri);

                    Log.Track(Const.OPEN_TRANSFERMOVIL);
                });
                e.Cancel = true;
            }
        }

        public async Task DoActionAsync(int action, string query = null)
        {
            int i = 0;
            int timeToDelay = 500;
            List<Tienda> tiendas = App.HostApp.AppModel.GetSelected();
            if (tiendas.Any())
            {
                foreach (ContentPage page in Children)
                {
                    switch (action)
                    {
                        case 1: //Refresh
                            RefreshCurrentWebView(page);
                            break;
                        case 2: //Find
                            string newUrl = tiendas.ElementAt(i).URL + Const.URL_SEARCH + '"' + query + '"';
                            FindInCurrentTab(page, newUrl);
                            break;
                    }

                    Task.Delay(timeToDelay).Wait();
                    i++;
                }
            }
        }

        public void RefreshCurrentWebView(ContentPage page)
        {
            MyCustomWebView webview = (page.Content as Grid).Children[0] as MyCustomWebView;
            webview.Reload();
        }

        public void FindInCurrentTab(ContentPage page, string newUrl)
        {

            MyCustomWebView webview = (page.Content as Grid)?.Children[0] as MyCustomWebView;
            UpdateWebView(webview.Parent as Grid, new UrlWebViewSource { Url = newUrl });
            WebView = webview;
        }
        public MyCustomWebView UpdateWebView(Grid container, UrlWebViewSource newURL)
        {

            MyCustomWebView webView = new MyCustomWebView
            {
                Source = newURL,
                Title = WebView.Title
            };
            container.Children.Clear();
            container.Children.Add(webView, 0, 0);
            AddAds();

            return webView;
        }

        public void OpenUrl(string url)
        {
            Navigation.PushAsync(new WebViewNavigation(url));
        }

        public void NavigateToTabIndex(int index)
        {
            CurrentPage = Children[index];
        }

        protected override bool OnBackButtonPressed()
        {
            if (WebView.CanGoBack)
            {
                WebView.GoBack();
                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

    }
}