using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisiTour.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindFlightsPage : ContentPage
    {
        FindFlightsViewModel model = null;
        public FindFlightsPage()
        {
            InitializeComponent();
            BindingContext = model = new FindFlightsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitCities();
            await model.InitClasses();

        }

        private async void Search_Clicked(object sender, EventArgs e)
        {
            await model.getSearched();
            await Navigation.PushAsync(new SearchedFlightsPage());
          
        }
    }
}