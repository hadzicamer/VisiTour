using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Mobile.ViewModels;
using VisiTour.Model;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace VisiTour.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpecialOffersPage : ContentPage
    {
        SpecialOffersViewModel model = null;

        public SpecialOffersPage()
        {
            InitializeComponent();
            BindingContext = model = new SpecialOffersViewModel();
        }
        protected async override void OnAppearing()
        {
            await model.InitOffers();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as SpecialOffers;
            await Navigation.PushAsync(new RecommendedCityToPage(item));
        }
    }
}