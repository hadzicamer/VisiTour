using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Services
{
    public interface ICustomerService
    {
        List<Model.Customers> Get(CustomerSearchRequest request);

        Model.Customers GetById(int id);

        Model.Customers Insert(CustomersUpsertRequest request);
        Model.Customers Update(int id,CustomersUpsertRequest request);

        Model.Customers Delete(int id);

        Model.Customers Autentifikacija(string mail, string pass);

    }
}
