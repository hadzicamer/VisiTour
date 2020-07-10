using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Mobile.ViewModels;
using VisiTour.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisiTour.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecommendedCityToPage : ContentPage
    {
        
        RecommendedCityToViewModel model = null;
        public RecommendedCityToPage(SpecialOffers specialOffers)
        {
            InitializeComponent();
            BindingContext = model = new RecommendedCityToViewModel
            {
                Offers = specialOffers
            };
        }

        protected async override void OnAppearing()
        {
            await model.LoadRecommendedCityTo();
        }
    }
}
