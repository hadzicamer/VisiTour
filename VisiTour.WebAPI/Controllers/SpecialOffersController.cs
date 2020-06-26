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

    public class SpecialOffersController : BaseCRUDController<Model.SpecialOffers, SpecialOffersSearchRequest, SpecialOffersUpsertRequest, SpecialOffersUpsertRequest>
    {
        public SpecialOffersController(ICRUDService<Model.SpecialOffers, SpecialOffersSearchRequest, SpecialOffersUpsertRequest, SpecialOffersUpsertRequest> service) : base(service)
        {

        }
    }
}