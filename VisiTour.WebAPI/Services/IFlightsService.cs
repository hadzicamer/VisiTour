using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Services
{
    public interface IFlightsService
    {
        List<Model.Flights> Get(FlightsSearchRequest request);
        Model.Flights GetById(int id);
        Model.Flights Update(int id, FlightsUpsertRequest request);
        Model.Flights Insert(FlightsUpsertRequest request);
        Model.Flights Delete(int id);
    }
}
