using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisiTour.WebAPI.Services
{
    public interface ICitiesService
    {
        List<Model.Cities> Get();
        Model.Cities GetById(int id);
        List<Model.Cities> Recommend(int id);

    }
}
