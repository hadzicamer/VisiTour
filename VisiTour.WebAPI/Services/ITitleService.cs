using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisiTour.WebAPI.Services
{
    public interface ITitleService
    {
        List<Model.Title> Get();
        Model.Title GetById(int id);
    }
}
