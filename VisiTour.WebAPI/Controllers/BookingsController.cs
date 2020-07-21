using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private IBookingsService _service;
        public BookingsController(IBookingsService service)
        {
            _service = service;
        }
        
        [Authorize(Roles = "User")]
        [HttpGet]
        public List<Model.Bookings> Get([FromQuery]BookingsSearchRequest search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]

        public Model.Bookings GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.Bookings Insert(BookingInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}