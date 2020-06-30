using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;

namespace VisiTour.Mobile.ViewModels
{
    public class SearchedFlightsViewModel
    {
        public ObservableCollection<Flights> FlightsList { get; set; } = new ObservableCollection<Flights>();
        private readonly APIService _flightsService = new APIService("Flights");

        public FindFlightsViewModel search { get; set; }

        public async Task getSearched()
        {

            FlightsSearchRequest srch = new FlightsSearchRequest
            {
                FlightFrom = search.FlightFrom,
                FlightTo = search.FlightTo,
                selectedClass = search.Class,
                DateFrom = search.DateFrom,
                DateTo = search.DateTo
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
