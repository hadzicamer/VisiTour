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

    public class CompaniesController : BaseCRUDController<Model.Companies,CompaniesSearchRequest, CompaniesUpsertRequest, CompaniesUpsertRequest>
    {
        public CompaniesController(ICRUDService<Model.Companies, CompaniesSearchRequest, CompaniesUpsertRequest, CompaniesUpsertRequest> service) : base(service)
        {
        }
    }
}