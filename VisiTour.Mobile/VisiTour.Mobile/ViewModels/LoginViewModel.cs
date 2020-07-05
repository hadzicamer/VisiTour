using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Mobile.Views;
using VisiTour.Model;
using VisiTour.Model.Requests;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{

    public class LoginViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Bookings");
        private readonly APIService _serviceUser = new APIService("Customers");
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
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                var y = await _service.Get<List<Bookings>>(null);
                if(y != default)
                {
                    var temp = await _serviceUser.Get<List<Customers>>(new CustomerSearchRequest
                    {
                        Username = Username
                    });
                    APIService.Customers = temp.FirstOrDefault();
                    APIService.Customers.CustomerId = temp.Select(x => x.CustomerId).FirstOrDefault();
                    Application.Current.MainPage = new MainPage();
                }

            }
            catch (Exception ex)
            {
                
            }
        }
    }

}
