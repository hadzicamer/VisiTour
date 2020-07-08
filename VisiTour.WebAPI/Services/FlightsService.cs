using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.ML;

namespace VisiTour.WebAPI.Services
{
    public class FlightsService : BaseCRUDService<Model.Flights,FlightsSearchRequest,Database.Flights,FlightsUpsertRequest,FlightsUpsertRequest>
    {
       static MLContext mLContext = null;
        static ITransformer model = null;
        public FlightsService(IB170172Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Flights> Get([FromQuery]FlightsSearchRequest request)
        {
            var query = _context.Flights.Include(x=>x.FlightClass).Include(x=>x.CityFrom).Include(x=>x.CityTo).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.selectedFlightFrom))
            {
                query = query.Where(x => x.CityFrom.Name.StartsWith(request.selectedFlightFrom));
            }

            if (!string.IsNullOrWhiteSpace(request?.selectedFlightTo))
            {
                query = query.Where(x => x.CityTo.Name.StartsWith(request.selectedFlightTo));
            }
          
            if (request?.DateFrom!=null)
            {
                query = query.Where(x => x.DateFrom==request.DateFrom);
            }
            if (request?.DateTo!=null)
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

