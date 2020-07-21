using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var query = _context.Bookings.Include(x=>x.Flight).Include(x => x.Flight.FlightClass).Include(x => x.Flight.CityFrom).Include(x => x.Flight.CityTo).Include(x => x.Flight.Company).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }
            if (request?.CustomerId != null)
            {
                query = query.Where(x => x.CustomerId == request.CustomerId);
            }

            return _mapper.Map<List<Model.Bookings>>(query);
        }

        public Model.Bookings GetById(int id)
        {
            var e = _context.Set<Bookings>().Find(id);
            return _mapper.Map<Model.Bookings>(e);
        }


        public Model.Bookings Insert(BookingInsertRequest request)
        {
            var e = _mapper.Map<Bookings>(request);

            _context.Bookings.Add(e);

            _context.SaveChanges();

            return _mapper.Map<Model.Bookings>(e);
        }
    }
}
