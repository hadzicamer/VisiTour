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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            lblName.Text = APIService.Customers.Username;
            lblCountry.Text = APIService.Customers.Country;
            lblBirthDate.Text = APIService.Customers.DateOfBirth.ToString().Substring(0, 9);
            lblEmail.Text = APIService.Customers.Email;
        }



    }
}