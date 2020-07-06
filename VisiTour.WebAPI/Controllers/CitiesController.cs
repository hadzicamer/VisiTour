using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.Model;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{

    public class CitiesController : ControllerBase
    {
        private ICitiesService _service;
        public CitiesController(ICitiesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("{id}/Recommend")]
        public List<Cities> Recommend(int id)
        {
            return _service.Recommend(id);
        }

    }

}