using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Services
{
    public interface IRecommendService
    {
        List<Model.Cities> Recommend(RecommendSearchRequest obj);
    }

}
