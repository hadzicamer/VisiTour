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
    public class CompaniesService:BaseCRUDService<Model.Companies,CompaniesSearchRequest,Companies,CompaniesUpsertRequest, CompaniesUpsertRequest>
    {
        public CompaniesService(IB170172Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Companies> Get([FromQuery]CompaniesSearchRequest request)
        {
            var query = _context.Companies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Companies>>(query);
        }

    }
}

