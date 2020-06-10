using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Controls;
using TuEnvio.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTab : TabbedPage
    {
        private MyCustomWebView webView;

        public MainTab()
        {
            InitializeComponent();
        }

        private async Task<string> GetTitle()
        {
            return await webView.EvaluateJavaScriptAsync("$(document).find('title').text();");
        }

        private void refresh_Clicked(object sender, EventArgs e)
        {
            webView.WidthRequest = UtilsXF.GetScreenWidth();
            webView.HeightRequest = UtilsXF.GetScreenHeight();
            webView.Reload();
        }

        private async void share_Clicked(object sender, EventArgs e)
        {
            string title = await GetTitle();
            string[] line = title.Split(new[] { "\\r\\n", "\\r", "\\n" }, StringSplitOptions.None);
            string formatTitle = UtilsXF.RemoveSpecialCharacters(line[4]).Trim();

            _ = ShareUtils.ShareText(formatTitle, ((UrlWebViewSource)webView.Source).Url);
        }

        string currentPageName = "";
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            try {
                currentPageName = CurrentPage.Title;

                webView = (((CurrentPage as ContentPage).Content as AbsoluteLayout).Children[0] as StackLayout).Children[0] as MyCustomWebView;
            }
            catch (Exception e) { 
            
            }
            
        }
    }
}