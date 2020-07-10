using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.ML;

namespace VisiTour.WebAPI.Services
{
    public class CitiesService : ICitiesService
    {
    
        private readonly IB170172Context _context;
        private readonly IMapper _mapper;
        public CitiesService(IB170172Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Cities> Get()
        {
            var list = _context.Set<Database.Cities>().ToList();
            return _mapper.Map<List<Model.Cities>>(list);
        }

        public Model.Cities GetById(int id)
        {
            var e = _context.Set<Database.Cities>().Find(id);
            return _mapper.Map<Model.Cities>(e);
        }

     

    }
}

