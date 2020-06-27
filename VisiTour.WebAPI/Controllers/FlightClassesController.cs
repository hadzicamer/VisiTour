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

    public class FlightClassesController : BaseController<Model.FlightClasses, object>
    {
        public FlightClassesController(IService<FlightClasses, object> service) : base(service)
        {
        }
    }
}