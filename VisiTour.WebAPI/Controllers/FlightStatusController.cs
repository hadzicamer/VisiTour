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

    public class FlightStatusController : BaseController<Model.FlightStatus, object>
    {
        public FlightStatusController(IService<FlightStatus, object> service) : base(service)
        {
        }
    }
}