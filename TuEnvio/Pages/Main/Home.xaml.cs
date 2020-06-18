using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : MasterDetailPage
    {
        public bool PreventSave { get; set; }

        public Home()
        {
            InitializeComponent();

            //MasterPage.Search.Clicked -= Search_ClickedAsync;
            //MasterPage.Search.Clicked += Search_ClickedAsync;

            MasterPage.Share.Clicked -= Share_Clicked;
            MasterPage.Share.Clicked += Share_Clicked;

            MasterPage.Refresh.Clicked -= Refresh_Clicked;
            MasterPage.Refresh.Clicked += Refresh_Clicked;

            MasterPage.Help.Clicked -= Help_Clicked;
            MasterPage.Help.Clicked += Help_Clicked;

            MasterPage.Update.Clicked -= Update_Clicked;
            MasterPage.Update.Clicked += Update_Clicked;

            //IsPresentedChanged += Home_IsPresentedChanged;

        }

        private void Update_Clicked(object sender, EventArgs e)
        {
            CloseMaster();
        }

        private void Help_Clicked(object sender, EventArgs e)
        {
            DetailsPage.Navigation.PushAsync(new Help());
            Log.Track(Const.OPEN_HELP);
            OnlyClose();
        }

        private async void Refresh_Clicked(object sender, EventArgs e)
        {
            await DetailsPage.DoActionAsync(1);
            Log.Track(Const.REFRESH_ALL);
            OnlyClose();
        }

        private void Share_Clicked(object sender, EventArgs e)
        {
            DetailsPage.ShareLinkAsync();
            Log.Track(Const.SHARE_LINK);
            OnlyClose();
        }

        private async void Search_ClickedAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MasterPage.Keyword.Text))
            {
                await DetailsPage.DoActionAsync(2, MasterPage.Keyword.Text);
                Log.Track(Const.SEARCH);
                OnlyClose();
            }
        }

        public void CloseMaster()
        {
            if (App.HostApp.AppModel.IsChanged)
            {
                App.HostApp.AppModel.UpdatePreferences();
                ((Detail as NavigationPage).RootPage as HomeDetails).Init();

                Log.Track(Const.SAVE_CHANGES);
            }
            OnlyClose();
        }

        public void OnlyClose()
        {
            IsPresented = false;
            PreventSave = true;
        }

    }
}