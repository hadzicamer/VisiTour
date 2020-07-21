using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Mobile.ViewModels;
using VisiTour.Model;
using VisiTour.Model.Requests;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisiTour.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchedFlightsPage : ContentPage
    {
        SearchedFlightsViewModel model = null;
        public SearchedFlightsPage(FindFlightsViewModel search)
        {
            InitializeComponent();
            BindingContext = model = new SearchedFlightsViewModel()
            {
                search = search
            };
        }

        protected async override void OnAppearing()
        {
            await model.getSearched();
        }

        private async void listFlight_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Flights;
            await Navigation.PushAsync(new BookingPage(item));
        }
    }
}

