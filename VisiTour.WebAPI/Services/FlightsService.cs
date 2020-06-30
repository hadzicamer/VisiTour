using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;

namespace VisiTour.WebAPI.Services
{
    public class FlightsService : BaseCRUDService<Model.Flights,FlightsSearchRequest,Database.Flights,FlightsUpsertRequest,FlightsUpsertRequest>
    {
        public FlightsService(IB170172Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Flights> Get([FromQuery]FlightsSearchRequest request)
        {
            var query = _context.Flights.Include(x=>x.FlightClass).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.FlightFrom))
            {
                query = query.Where(x => x.FlightFrom.StartsWith(request.FlightFrom));
            }
            if(!string.IsNullOrWhiteSpace(request?.FlightTo))
            {
                query = query.Where(x => x.FlightTo.StartsWith(request.FlightTo));
            }
            if (!string.IsNullOrWhiteSpace(request?.FlightTo))
            {
                query = query.Where(x => x.FlightTo.StartsWith(request.FlightTo));
            }
            if (!string.IsNullOrWhiteSpace(request?.DateFrom.ToShortDateString()))
            {
                query = query.Where(x => x.DateFrom==request.DateFrom);
            }
            if (!string.IsNullOrWhiteSpace(request?.DateTo.ToShortDateString()))
            {
                query = query.Where(x => x.DateTo == request.DateTo);
            }
            if (!string.IsNullOrWhiteSpace(request?.selectedClass))
            {
                query = query.Where(x => x.FlightClass.Name.StartsWith(request.selectedClass));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Flights>>(query);
        }
    }
}
