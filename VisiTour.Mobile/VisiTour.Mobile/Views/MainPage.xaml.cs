using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VisiTour.Mobile.Models;
using VisiTour.Mobile.ViewModels;
using VisiTour.Model;

namespace VisiTour.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                    case (int)MenuItemType.Bookings:
                        MenuPages.Add(id, new NavigationPage(new MyBookingPage()));
                        break;
                    case (int)MenuItemType.Classes:
                        MenuPages.Add(id, new NavigationPage(new ClassesPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.FindFlights:
                        MenuPages.Add(id, new NavigationPage(new FindFlightsPage()));
                        break;
                    case (int)MenuItemType.Offers:
                        MenuPages.Add(id, new NavigationPage(new SpecialOffersPage()));
                        break;
                    case (int)MenuItemType.Exam:
                        MenuPages.Add(id, new NavigationPage(new ExamPage()));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}