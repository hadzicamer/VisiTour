using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;

namespace VisiTour.WebAPI.Services
{
    public class PaymentsService : BaseCRUDService<Model.Payments,PaymentsSearchRequest,Database.Payments,PaymentsUpsertRequest,PaymentsUpsertRequest>
    {
        public PaymentsService(IB170172Context context,IMapper mapper) : base(context, mapper)
        {

        }
        public override List<Model.Payments> Get([FromQuery]PaymentsSearchRequest request)
        {
            var query = _context.Payments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.PaymentMethod))
            {
                query = query.Where(x => x.PaymentMethod.StartsWith(request.PaymentMethod));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Payments>>(query);
        }
    }
}
