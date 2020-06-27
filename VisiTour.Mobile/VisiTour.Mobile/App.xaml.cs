﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VisiTour.Mobile.Services;
using VisiTour.Mobile.Views;

namespace VisiTour.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
