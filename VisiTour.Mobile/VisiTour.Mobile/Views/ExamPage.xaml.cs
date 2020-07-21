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
    public partial class ExamPage : ContentPage
    {

        ExamViewModel model = null;
        public ExamPage()
        {
            InitializeComponent();
            BindingContext = model = new ExamViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitClasses();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.getSearched();
        }
    }
}