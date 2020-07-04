using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Mobile.ViewModels;
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
            //await model.InitCities();
            //await model.InitCompanies();
            await model.InitOffers();

        }
    }
}