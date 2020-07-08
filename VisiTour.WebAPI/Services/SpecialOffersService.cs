using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.ML;

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

            var list = query.ToList();
            return _mapper.Map<List<Model.SpecialOffers>>(query);
        }

      
    }
}
