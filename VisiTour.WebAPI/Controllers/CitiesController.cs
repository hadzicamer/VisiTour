using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.Model;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{

    public class CitiesController : BaseController<Model.Cities, object>
    {
        public CitiesController(IService<Cities, object> service) : base(service)
        {

        }

       
    }
}