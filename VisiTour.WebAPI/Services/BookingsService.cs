using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;

namespace VisiTour.WebAPI.Services
{
    public class BookingsService :IBookingsService
    {
        private readonly IB170172Context _context;
        private readonly IMapper _mapper;

        public BookingsService(IB170172Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Bookings> Get([FromQuery]BookingsSearchRequest request)
        {
            var query = _context.Bookings.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Details))
            {
                query = query.Where(x => x.Details.Contains(request.Details));
            }
                return _mapper.Map<List<Model.Bookings>>(query);
        }

        public Model.Bookings GetById(int id)
        {
            var e = _context.Set<Bookings>().Find(id);
            return _mapper.Map<Model.Bookings>(e);
        }
    }
}
