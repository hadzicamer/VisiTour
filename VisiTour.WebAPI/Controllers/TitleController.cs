using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private ITitleService _service;
        public TitleController(ITitleService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Title> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]

        public Model.Title GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
