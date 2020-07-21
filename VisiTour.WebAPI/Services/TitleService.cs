using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.WebAPI.Database;

namespace VisiTour.WebAPI.Services
{
    public class TitleService:ITitleService
    {
        private readonly IB170172Context _context;
        private readonly IMapper _mapper;
        public TitleService(IB170172Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Title> Get()
        {
            var list = _context.Set<Title>().ToList();
            return _mapper.Map<List<Model.Title>>(list);
        }

        public Model.Title GetById(int id)
        {
            var e = _context.Set<Title>().Find(id);
            return _mapper.Map<Model.Title>(e);
        }

    }
}
