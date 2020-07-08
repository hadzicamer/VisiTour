using System;
using System.Windows.Input;
using VisiTour.Mobile.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
        }

        public ICommand OpenWebCommand { get; }
    }
}