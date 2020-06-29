using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Model;
using VisiTour.Model.Requests;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class FindFlightsViewModel:BaseViewModel
    {
        private readonly APIService _citiesService = new APIService("Cities");
        private readonly APIService _classesService = new APIService("FlightClasses");
        private readonly APIService _flightsService = new APIService("Flights");

        public FindFlightsViewModel()
        {
            CitiesCommand = new Command(async () => await InitCities());
            ClassesCommand = new Command(async () => await InitClasses());
            FlightsCommand = new Command(async () => await getSearched());

        }

        public ObservableCollection<Cities> CitiesList { get; set; } = new ObservableCollection<Cities>();
        public ObservableCollection<FlightClasses> ClassesList { get; set; } = new ObservableCollection<FlightClasses>();

        public ICommand CitiesCommand { get; set; }
        public ICommand ClassesCommand { get; set; }
        public ICommand FlightsCommand { get; set; }

        string _FlightFrom = string.Empty;
        public string FlightFrom
        {
            get { return _FlightFrom; }
            set { SetProperty(ref _FlightFrom, value); }
        }

        string _FlightTo = string.Empty;
        public string FlightTo
        {
            get { return _FlightTo; }
            set { SetProperty(ref _FlightTo, value); }
        }

        private Cities _selectedCityFrom;
        public Cities SelectedCityFrom
        {
            get { return _selectedCityFrom; }
            set
            {
                _selectedCityFrom = value;
                OnPropertyChanged();
            }
        }

        private Cities _selectedCityTo;
        public Cities SelectedCityTo
        {
            get { return _selectedCityTo; }
            set
            {
                _selectedCityTo = value;
                OnPropertyChanged();
            }
        }

        private FlightClasses _selectedClass;
        public FlightClasses SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                OnPropertyChanged();
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

        public List<Flights> FlightsList { get; set; } = new List<Flights>();

        public async Task getSearched()
        {
            //APIService.Flights.FlightFrom = FlightFrom;
            //APIService.Flights.FlightTo = FlightTo;

            FlightsSearchRequest srch = new FlightsSearchRequest
            {
                FlightFrom = FlightFrom,
                FlightTo = FlightFrom
            };
            var temp = await _flightsService.Get<List<Flights>>(srch);
            FlightsList = temp;
        }


    }
}
