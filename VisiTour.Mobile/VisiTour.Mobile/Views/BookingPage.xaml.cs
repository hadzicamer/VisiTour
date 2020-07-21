using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Mobile.Models;
using VisiTour.Mobile.ViewModels;
using VisiTour.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisiTour.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingPage : ContentPage
    {
        BookingsViewModel model = null;
        Flights flights = null;
        public BookingPage(Flights item)
        {
            InitializeComponent();
            flights = item;
            BindingContext = model = new BookingsViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitTitles();
            await model.InitCountries();
        }



        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            model.FirstName = name.Text;
            model.LastName = surname.Text;
            model.Email = email.Text;
            model.FlightId = flights.FlightId;
            await Navigation.PushAsync(new CheckPage(model));
        }
    }
}