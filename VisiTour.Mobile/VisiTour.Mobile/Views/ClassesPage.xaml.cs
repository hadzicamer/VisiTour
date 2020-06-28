using System;
using System.Collections.Generic;
using System.IO;
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
    private readonly APIService _classesService = new APIService("FlightClasses");
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

 

        private void CompaniesPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompaniesPicker.IsVisible = true;
            Func<Stream> func = () => new MemoryStream(model.SelectedCompany.photo);
            imgCompany.Source =ImageSource.FromStream(func);
            lblhq.Text = model.SelectedCompany.Headquarter;
            lblFy.Text = model.SelectedCompany.FoundingYear;
        }

        private void ClassesPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassesPicker.IsVisible = true;
            txtClass.Text = model.SelectedClass.Description;
        }


        //private async void CompaniesPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var sel =CompaniesPicker.SelectedItem as string;
        //        await Navigation.PushModalAsync(new NavigationPage(new ChoosedClassPage()));

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}