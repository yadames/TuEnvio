using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
        }

        private async Task<string> GetTitle()
        {
            return await webview.EvaluateJavaScriptAsync("$(document).find('title').text();");
        }

        private void refresh_Clicked(object sender, EventArgs e)
        {
            webview.WidthRequest = UtilsXF.GetScreenWidth();
            webview.HeightRequest = UtilsXF.GetScreenHeight();
            webview.Reload();
        }

        private async void share_Clicked(object sender, EventArgs e)
        {
            string title = await GetTitle();
            string[] line = title.Split(new[] { "\\r\\n", "\\r", "\\n" }, StringSplitOptions.None);
            string formatTitle = UtilsXF.RemoveSpecialCharacters(line[4]).Trim();

            _ = ShareUtils.ShareText(formatTitle, ((UrlWebViewSource)webview.Source).Url);
        }
    }
}