using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Services
{
   public interface IBookingsService
    {
        List<Model.Bookings> Get(BookingsSearchRequest request);

        Model.Bookings GetById(int id);
        Model.Bookings Insert(BookingInsertRequest request);
    }
}
