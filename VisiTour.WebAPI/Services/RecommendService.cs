using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class RecommendService : IRecommendService
    {
        private readonly IB170172Context _context;
        private readonly IMapper _mapper;

        public RecommendService(IB170172Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        static MLContext mLContext = null;
        static ITransformer model = null;
        public List<Model.Cities> Recommend(RecommendSearchRequest obj)
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
                                data.Add(new 
                                    ProductEntry() { ProductID = (uint)y, CoPurchaseProductID = (uint)z.CityToId });
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
            var all = _context.Cities.Where(x => x.CityId != obj.CityToID).ToList();
            var predictionRes = new List<Tuple<Database.Cities, float>>();
            foreach (var item in all)
            {
                var predictionengine = mLContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                                         new ProductEntry()
                                         {
                                             ProductID = (uint)obj.CityToID,
                                             CoPurchaseProductID = (uint)item.CityId
                                         });
                predictionRes.Add(new Tuple<Database.Cities, float>(item, prediction.Score));
            }

            var finalRes = predictionRes.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(2).ToList();
            return _mapper.Map<List<Model.Cities>>(finalRes);
        }
    }
}
