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
        private readonly APIService _flightsService = new APIService("Flights");
        public ObservableCollection<Flights> FlightsList { get; set; } = new ObservableCollection<Flights>();

        public FindFlightsViewModel search { get; set; }

        public async Task getSearched()
        {

            FlightsSearchRequest srch = new FlightsSearchRequest
            {
                selectedFlightFrom = search.FlightFrom,
                selectedFlightTo = search.FlightTo,
                selectedClass = search.Class,
                DateFrom = search.DateFrom,
                DateTo = search.DateTo,
                Price=search.Price
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
