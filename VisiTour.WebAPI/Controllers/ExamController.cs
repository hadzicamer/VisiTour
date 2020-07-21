using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private IExamService _service;
        public ExamController(IExamService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Flights> Get([FromQuery] ExamSearchRequest obj)
        {
            return _service.Get(obj);
        }

    }
}
