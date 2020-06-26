using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.Model;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{

    public class FlightSeatsController : BaseController<Model.FlightSeats, object>
    {
        public FlightSeatsController(IService<FlightSeats, object> service) : base(service)
        {
        }
    }
}