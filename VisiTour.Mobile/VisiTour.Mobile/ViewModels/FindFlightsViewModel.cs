using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Mobile.Views;
using VisiTour.Model;
using VisiTour.Model.Requests;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class FindFlightsViewModel:BaseViewModel
    {
        private readonly APIService _citiesService = new APIService("Cities");
        private readonly APIService _classesService = new APIService("FlightClasses");

     

        public FindFlightsViewModel()
        {
            CitiesCommand = new Command(async () => await InitCities());
            ClassesCommand = new Command(async () => await InitClasses());

        }

        public ObservableCollection<Cities> CitiesList { get; set; } = new ObservableCollection<Cities>();
        public ObservableCollection<FlightClasses> ClassesList { get; set; } = new ObservableCollection<FlightClasses>();

        public ICommand CitiesCommand { get; set; }
        public ICommand ClassesCommand { get; set; }


        string _FlightFrom = string.Empty;
        public string FlightFrom
        {
            get { return _FlightFrom; }
            set
            {
                if (_FlightFrom != value)
                {
                    _FlightFrom = value;
                }
            }
        }
        

        string _FlightTo = string.Empty;
        public string FlightTo
        {
            get { return _FlightTo; }
            set
            {
                if (_FlightTo != value)
                {
                    _FlightTo = value;
                }
            }
        }

        string _Class = string.Empty;
        public string Class
        {
            get { return _Class; }
            set
            {
                if (_Class != value)
                {
                    _Class = value;
                }
            }
        }

        private Cities _selectedCityFrom;
        public Cities SelectedCityFrom
        {
            get { return _selectedCityFrom; }
            set
            {
                _selectedCityFrom = value;
                FlightFrom = value.Name;
            }
        }

        private Cities _selectedCityTo;
        public Cities SelectedCityTo
        {
            get { return _selectedCityTo; }
            set
            {
                _selectedCityTo = value;
                FlightTo = value.Name;
            }
        }


        private FlightClasses _selectedClass;

        public FlightClasses SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                Class = value.Name;
            }
        }

        private DateTime? _dateFrom = null;
        public DateTime? DateFrom
        {
            get { return _dateFrom; }
            set
            {
                _dateFrom = value;

            }
        }

        private DateTime? _dateTo = null;
        public DateTime? DateTo
        {
            get { return _dateTo; }
            set
            {
                _dateTo = value;
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }


        public async Task InitCities()
        {
            if (CitiesList.Count == 0)
            {
                var list = await _citiesService.Get<List<Cities>>(null);

                CitiesList.Clear();
                foreach(var cities in list)
                {
                    CitiesList.Add(cities);
                }
            }
        }

        public async Task InitClasses()
        {
            if (ClassesList.Count == 0)
            {
                var list = await _classesService.Get<List<FlightClasses>>(null);

                ClassesList.Clear();
                foreach (var classes in list)
                {
                    ClassesList.Add(classes);
                }
            }
        }


   


    }
}
