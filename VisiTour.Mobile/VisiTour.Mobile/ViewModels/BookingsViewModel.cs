using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Model;
using VisiTour.Model.Requests;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class BookingsViewModel
    {
        private readonly APIService _titleService = new APIService("Title");
        private readonly APIService _countriesService = new APIService("Countries");

        public BookingsViewModel()
        {
            TitlesCommand = new Command(async () => await InitTitles());
            CountriesCommand = new Command(async () => await InitCountries());
        }

      
        public ObservableCollection<Title> TitlesList { get; set; } = new ObservableCollection<Title>();
        public ObservableCollection<Countries> CountriesList { get; set; } = new ObservableCollection<Countries>();

        public int FlightId { get; set; }


        private Title _selectedTitle;
        public Title SelectedTitle
        {
            get { return _selectedTitle; }
            set
            {
                _selectedTitle = value;
            }
        }


        private Countries _selectedCountry;
        public Countries SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                _selectedCountry = value;
            }
        }


        string _FirstName = string.Empty;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                }
            }
        }

        string _LastName = string.Empty;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                }
            }
        }

        string _Email = string.Empty;
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                }
            }
        }


    
        private DateTime? _DateOfBirth = null;
        public DateTime? DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {
                _DateOfBirth = value;

            }
        }

        public ICommand TitlesCommand { get; set; }
        public ICommand CountriesCommand { get; set; }

        public async Task InitTitles()
        {
            if (TitlesList.Count == 0)
            {
                var list = await _titleService.Get<List<Title>>(null);

                TitlesList.Clear();
                foreach (var titles in list)
                {
                    TitlesList.Add(titles);
                }
            }
        }


        public async Task InitCountries()
        {
            if (CountriesList.Count == 0)
            {
                var list = await _countriesService.Get<List<Countries>>(null);

                CountriesList.Clear();
                foreach (var country in list)
                {
                    CountriesList.Add(country);
                }
            }
        }

    }
}
