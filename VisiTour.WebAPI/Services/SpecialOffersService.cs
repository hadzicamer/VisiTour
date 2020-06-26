using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;

namespace VisiTour.WebAPI.Services
{
    public class SpecialOffersService : BaseCRUDService<Model.SpecialOffers,SpecialOffersSearchRequest,SpecialOffers,SpecialOffersUpsertRequest,SpecialOffersUpsertRequest>
    {
        public SpecialOffersService(IB170172Context context, IMapper mapper) : base(context, mapper)
        {

        }


        // GLAVNI PROBLEM RIJESITI OVERRIDE GETA

        public override List<Model.SpecialOffers> Get(SpecialOffersSearchRequest request)
        {
 
            var query = _context.SpecialOffers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.DateFrom.ToString()) || !string.IsNullOrWhiteSpace(request?.DateTo.ToString()))
            {
                query = query.Where(x => x.DateFrom.ToString().StartsWith(request.DateFrom.ToString()) || x.DateTo.ToString().StartsWith(request.DateTo.ToString()));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.SpecialOffers>>(query);
        }
    }
}
