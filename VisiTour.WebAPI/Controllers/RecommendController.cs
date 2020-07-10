using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendController : ControllerBase
    {
        public IRecommendService _service { get; set; }

        public RecommendController(IRecommendService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Cities> Recommend([FromQuery]RecommendSearchRequest obj)
        {
            return _service.Recommend(obj);
        }

    }
}
