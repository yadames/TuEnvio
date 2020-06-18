using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TuEnvio.Model;
using TuEnvio.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuEnvio.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMaster : ContentPage
    {
        public ListView ListView;
        public Button Search { get; set; }
        public Entry Keyword { get; set; }
        public Button Share { get; set; }
        public Button Refresh { get; set; }
        public Button Help { get; set; }
        public Button Update { get; set; }

        public List<Tienda> ViewModel { get; internal set; }

        public HomeMaster()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {

            //Search = search_btn;
            //Keyword = search_entry;
            Share = share_btn;
            Refresh = refresh_btn;
            Help = help_btn;

            Update = new Button()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("D44141"),
                TextColor = Color.White,
                Margin = new Thickness(20, 5),
                Text = "GUARDAR CAMBIOS"
            };

            StackLayout labelLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 20,
                BackgroundColor = Color.FromHex("#D44141"),
                Children = {
                    new Label(){
                        Text = "Listado de tiendas",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    }
                }
            };

            ViewModel = App.HostApp.AppModel.Tiendas;

            BindingContext = ViewModel;

            listContent.Children.Clear();

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = ViewModel,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label()
                    {
                        FontAttributes = FontAttributes.Bold,
                    };
                    nameLabel.SetBinding(Label.TextProperty, "Nombre");

                    Label birthdayLabel = new Label();
                    birthdayLabel.SetBinding(Label.TextProperty, "Provincia");

                    CheckBox check = new CheckBox();
                    check.SetBinding(CheckBox.IsCheckedProperty, "IsSelected", BindingMode.TwoWay);

                    check.CheckedChanged -= Check_CheckedChanged;
                    check.CheckedChanged += Check_CheckedChanged;

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(20, 10),
                            Orientation = StackOrientation.Horizontal,
                            HeightRequest = 100,
                            Children =
                                {
                                    check,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel
                                        }
                                    }
                                }
                        }
                    };
                })
            };

            listContent.Children.Add(labelLayout);
            listContent.Children.Add(listView);
            listContent.Children.Add(Update);

            listView.ItemTapped -= ListView_ItemTapped;
            listView.ItemTapped += ListView_ItemTapped;

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tienda = ((sender as ListView).SelectedItem as Tienda);
            tienda.IsSelected = !tienda.IsSelected;
            (sender as ListView).SelectedItem = null;
        }

        private void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            App.HostApp.AppModel.IsChanged = true;
        }
    }
}