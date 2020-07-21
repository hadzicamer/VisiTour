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
    public partial class CheckPage : ContentPage
    {
        private readonly APIService _bookingService = new APIService("Bookings");
        BookingsViewModel BookingsViewModel = null;

        public CheckPage(BookingsViewModel model)
        {
            InitializeComponent();
            BookingsViewModel = model;
            title.Text = model.SelectedTitle.Name;
            firstName.Text = model.FirstName;
            lastName.Text = model.LastName;
            email.Text = model.Email;
            country.Text = model.SelectedCountry.Name;
            //date.Text = model.DateOfBirth.ToString().Substring(0, 10);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool question = await DisplayAlert("Message", "Would you like to book this flight?", "Yes", "No");
            if (question)
            {
                
                await _bookingService.Insert<Bookings>(new BookingInsertRequest()
                {
                    FlightId = BookingsViewModel.FlightId,
                    CustomerId=APIService.Customers.CustomerId
                });

                await DisplayAlert("Confirmation", "Flight has been booked!", "OK");
               
            }
        }
    }
}