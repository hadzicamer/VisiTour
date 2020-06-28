using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Mobile.Views;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Customers");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            APIService.Username = Username;
            APIService.Password = Password;
            try
            {
                await _service.Get<dynamic>(null);
                Application.Current.MainPage = new MainPage();

            }
            catch (Exception ex)
            {
            }
        }
    }

}
