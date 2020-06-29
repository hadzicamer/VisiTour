using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Mobile.ViewModels;
using VisiTour.Model.Requests;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisiTour.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchedFlightsPage : ContentPage
    {
        FindFlightsViewModel model = null;

        public SearchedFlightsPage()
        {
            InitializeComponent();
            BindingContext = model = new FindFlightsViewModel();
            lblFrom.Text = model.FlightFrom;
            lblTo.Text = model.FlightTo;
            //lblDateFrom.Text = model.ToString().Substring(0,9);
            //lblDateTo.Text = model.DateTo.ToString().Substring(0,9);
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await model.getSearched();
        //}
    }
}