using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{

    public class FlightsController : BaseCRUDController<Model.Flights, FlightsSearchRequest, FlightsUpsertRequest, FlightsUpsertRequest>
    {
        public FlightsController(ICRUDService<Flights, FlightsSearchRequest, FlightsUpsertRequest, FlightsUpsertRequest> service) : base(service)
        {
        }

     
      
    }
}