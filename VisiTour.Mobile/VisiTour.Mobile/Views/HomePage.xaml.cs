﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VisiTour.Mobile.Models;
using VisiTour.Mobile.Views;
using VisiTour.Mobile.ViewModels;

namespace VisiTour.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class HomePage : ContentPage
    {
        HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new HomeViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

        private async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void findFlights_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindFlightsPage());
        }

        private async void class_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassesPage());

        }

        private async void offer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpecialOffersPage());

        }
    }
}