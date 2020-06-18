using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Model;
using TuEnvio.Pages;
using TuEnvio.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio
{
    public partial class App : Application
    {
        public static App HostApp { get; private set; }

        public AppModel AppModel {  get; set; }

        public App()
        {
            HostApp = this;
            InitializeComponent();

            AppModel = new AppModel();

            MainPage = new Home();

            Log.Track(Const.INIT_APP);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public HomeDetails GetRootPage() 
        {
            return ((HostApp.MainPage as MasterDetailPage).Detail as NavigationPage).RootPage as HomeDetails; 
        }

        public static void ManageLink(string url) 
        {
            HomeDetails tabbedPage = App.HostApp.GetRootPage();
            tabbedPage.OpenUrl(url);
        }
    }
}
