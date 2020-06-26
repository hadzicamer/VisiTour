using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Services
{
    public interface ISpecialOffersService
    {
        List<SpecialOffers> Get(SpecialOffersSearchRequest request);

       SpecialOffers GetById(int id);

        Model.SpecialOffers Insert(SpecialOffersUpsertRequest request);
        Model.SpecialOffers Update(int id, SpecialOffersUpsertRequest request);

        Model.SpecialOffers Delete(int id);

    }
}
