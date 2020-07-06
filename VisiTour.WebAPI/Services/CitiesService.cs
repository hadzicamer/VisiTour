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
        static MLContext mLContext = null;
        static ITransformer model = null;
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

        List<Model.Cities> ICitiesService.Recommend(int id)
        {
            if (mLContext == null)
            {

                mLContext = new MLContext();


                var tmpData = _context.Companies.Include("SpecialOffers").ToList();

                var data = new List<ProductEntry>();
                foreach (var x in tmpData)
                {
                    if (x.SpecialOffers.Count > 1)
                    {
                        var distinctItem = x.SpecialOffers.Select(x => x.CityToId).ToList();
                        distinctItem.ForEach(y =>
                        {
                            var related = x.SpecialOffers.Where(z => z.CityToId != y).ToList();
                            related.ForEach(z =>
                            {
                                data.Add(new ProductEntry() { ProductID = (uint)y, CoPurchaseProductID = (uint)z.CityToId });
                            });
                        });
                    }
                }

                var traindata = mLContext.Data.LoadFromEnumerable(data);
                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                options.C = 0.00001;
                var est = mLContext.Recommendation().Trainers.MatrixFactorization(options);
                model = est.Fit(traindata);
            }
            var all = _context.Cities.Where(x => x.CityId != id).ToList();
            var predictionRes = new List<Tuple<Database.Cities, float>>();
            foreach (var item in all)
            {
                var predictionengine = mLContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                                         new ProductEntry()
                                         {
                                             ProductID = (uint)id,
                                             CoPurchaseProductID = (uint)item.CityId
                                         });
                predictionRes.Add(new Tuple<Database.Cities, float>(item, prediction.Score));
            }

            var finalRes = predictionRes.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(2).ToList();
            return _mapper.Map<List<Model.Cities>>(finalRes);
        }

    }
}

