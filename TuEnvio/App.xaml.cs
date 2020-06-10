using System;
using TuEnvio.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio
{
    public partial class App : Application
    {
        public static App HostApp { get; private set; }

        public App()
        {
            HostApp = this;
            InitializeComponent();

            MainPage = new MainTab();
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
    }
}
