using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI.Controllers
{
    [Authorize(Roles = "Administrator")]

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController :ControllerBase
    {
        private ICustomerService _service;
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Customers> Get([FromQuery]CustomerSearchRequest search)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]

        public Model.Customers GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.Customers Insert(CustomersUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Customers Update(int id, CustomersUpsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public Model.Customers Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}