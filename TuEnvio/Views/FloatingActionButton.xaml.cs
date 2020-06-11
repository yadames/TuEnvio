using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingActionButton : ContentView
    {
        //public const string URL = https://www.tuenvio.cu/carlos3/Search.aspx?keywords=%22papel%22&depPid=0;

        public FloatingActionButton()
        {
            InitializeComponent();
        }

        private void search_click(object sender, EventArgs e) 
        {

            MainTab tabbedPage = App.HostApp.MainPage as MainTab;

            tabbedPage.FindInAllTabs(search_entry.Text);

            IsVisible = false;
        }

        private void share_click(object sender, EventArgs e)
        {
            MainTab tabbedPage = App.HostApp.MainPage as MainTab;
            tabbedPage.ShareLinkAsync();
        }
    }
}