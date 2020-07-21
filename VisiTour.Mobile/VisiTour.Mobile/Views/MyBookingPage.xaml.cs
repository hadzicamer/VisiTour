using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MyBookingPage : ContentPage
    {
        private readonly APIService _bookingService = new APIService("Bookings");
        public ObservableCollection<Flights> BookedFlightsList { get; set; } = new ObservableCollection<Flights>();

        FindFlightsViewModel model = null;
        public MyBookingPage()
        {
            InitializeComponent();
            BindingContext = model = new FindFlightsViewModel();
        }

      
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.getBookings();
        }
    }
}