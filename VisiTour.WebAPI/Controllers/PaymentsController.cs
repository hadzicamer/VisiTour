using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{
  
    public class PaymentsController : BaseCRUDController<Model.Payments,PaymentsSearchRequest,PaymentsUpsertRequest,PaymentsUpsertRequest>
    {
        public PaymentsController(ICRUDService<Model.Payments,PaymentsSearchRequest,PaymentsUpsertRequest,PaymentsUpsertRequest> service) : base(service)
        {

        }
    }
}