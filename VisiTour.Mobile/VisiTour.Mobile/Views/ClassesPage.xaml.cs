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
    public partial class ClassesPage : ContentPage
    {
        ClassesViewModel model = null;
        public ClassesPage()
        {
            InitializeComponent();
            BindingContext = model = new ClassesViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
           await model.InitClasses();
            await model.InitCompanies();

        }
    }
}