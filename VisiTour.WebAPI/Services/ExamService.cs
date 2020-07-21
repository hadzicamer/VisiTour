using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;

namespace VisiTour.WebAPI.Services
{
    public class ExamService : IExamService
    {


        private readonly IB170172Context _context;
        private readonly IMapper _mapper;
        public ExamService(IB170172Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Flights> Get([FromQuery]ExamSearchRequest request)
        {
            var query = _context.Flights.Include(x => x.FlightClass).Include(x=>x.CityFrom).Include(x=>x.CityTo).Include(x=>x.Company).AsQueryable();

            if (request?.DateFrom != null)
            {
                query = query.Where(x => x.DateFrom == request.DateFrom);
            }
            if (request?.DateTo != null)
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
