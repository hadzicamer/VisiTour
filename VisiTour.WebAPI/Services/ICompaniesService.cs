using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Services
{
   public interface ICompaniesService
    {
        List<Model.Companies> Get(CompaniesSearchRequest request);
        Model.Companies GetById(int id);
        Model.Companies Insert(CompaniesUpsertRequest request);
        Model.Companies Update(int id, CompaniesUpsertRequest request);
        Model.Companies Delete(int id);
    }
}
