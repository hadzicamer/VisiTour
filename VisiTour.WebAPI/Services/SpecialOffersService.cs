using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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


        public override List<Model.SpecialOffers> Get([FromQuery]SpecialOffersSearchRequest srch)
        {
 
            var query = _context.SpecialOffers.Include(x=>x.CityFrom).Include(x=>x.CityTo).Include(x=>x.Company).Include(x=>x.FlightClass).AsQueryable();


            //if (srch?.CityId.HasValue == true)
            //{
            //    query = query.OrderBy(x => x.CityFrom);
            //}

            //if (!string.IsNullOrWhiteSpace(request?.DateFrom.ToString()) || !string.IsNullOrWhiteSpace(request?.DateTo.ToString()))
            //{
            //    query = query.Where(x => x.DateFrom.ToString().Contains(request.DateFrom.ToString()) || x.DateTo.ToString().StartsWith(request.DateTo.ToString()));
            //}

            var list = query.ToList();
            return _mapper.Map<List<Model.SpecialOffers>>(query);
        }
    }
}
