using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;

namespace VisiTour.Mobile.ViewModels
{
    public class ExamViewModel:BaseViewModel
    {
        private readonly APIService _classesService = new APIService("FlightClasses");
        private readonly APIService _flightsService = new APIService("Flights");

        public ObservableCollection<FlightClasses> ClassesList { get; set; } = new ObservableCollection<FlightClasses>();
        public ObservableCollection<Flights> FlightsList { get; set; } = new ObservableCollection<Flights>();


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

        public async Task getSearched()
        {
            ExamSearchRequest srch = new ExamSearchRequest
            {
                selectedClass=Class,
                DateFrom = DateFrom,
                DateTo = DateTo,
            };
            var temp = await _flightsService.Get<List<Flights>>(srch);
            FlightsList.Clear();
            foreach (var item in temp)
            {
                FlightsList.Add(item);
            }
        }

    }
}
