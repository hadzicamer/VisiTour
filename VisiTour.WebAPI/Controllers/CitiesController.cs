using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using VisiTour.Model;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICitiesService _service;
        public CitiesController(ICitiesService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Cities> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]

        public Model.Cities GetById(int id)
        {
            return _service.GetById(id);
        }

        [AllowAnonymous]
        [HttpGet("{id}/Recommend")]
        public List<Cities> Recommend(int id)
        {
            return _service.Recommend(id);
        }

    }

}