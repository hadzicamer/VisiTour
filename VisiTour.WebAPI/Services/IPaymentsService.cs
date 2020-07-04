using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Services
{
    public interface IPaymentsService
    {
        List<Model.Payments> Get(PaymentsSearchRequest request);
        Model.Customers GetById(int id);
        Model.Customers Insert(PaymentsUpsertRequest request);
        Model.Customers Update(int id, PaymentsUpsertRequest request);
    }
}
