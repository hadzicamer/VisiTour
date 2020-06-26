using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.Mappers;

namespace VisiTour.WebAPI.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>,
        ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase:class
    {
        public BaseCRUDService(IB170172Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var e = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(e);

            _context.SaveChanges();

            return _mapper.Map<TModel>(e);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var e = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Attach(e);
            _context.Set<TDatabase>().Update(e);
            _mapper.Map(request, e);

            _context.SaveChanges();

            return _mapper.Map<TModel>(e);
        }

        public virtual TModel Delete(int id)
        {
            var e = _context.Set<TDatabase>().Find(id);
            if (e == null)
            {
                throw new ArgumentNullException();
            }
            var fresh = e;
            _context.Set<TDatabase>().Remove(e);
            _context.SaveChanges();
            return _mapper.Map<TModel>(fresh);

        }
    }
}
