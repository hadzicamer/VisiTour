using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.ML;

namespace VisiTour.WebAPI.Services
{
    public class FlightsService : BaseCRUDService<Model.Flights,FlightsSearchRequest,Database.Flights,FlightsUpsertRequest,FlightsUpsertRequest>,IFlightsService
    {
       static MLContext mLContext = null;
        public FlightsService(IB170172Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Flights> Get([FromQuery]FlightsSearchRequest request)
        {
            var query = _context.Flights.Include(x=>x.FlightClass).Include(x=>x.CityFrom).Include(x=>x.CityTo).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.selectedFlightFrom))
            {
                query = query.Where(x => x.CityFrom.Name.StartsWith(request.selectedFlightFrom));
            }

            if (!string.IsNullOrWhiteSpace(request?.selectedFlightTo))
            {
                query = query.Where(x => x.CityTo.Name.StartsWith(request.selectedFlightTo));
            }
          
            if (request?.DateFrom!=null)
            {
                query = query.Where(x => x.DateFrom==request.DateFrom);
            }
            if (request?.DateTo!=null)
            {
                query = query.Where(x => x.DateTo == request.DateTo);
            }
            if (!string.IsNullOrWhiteSpace(request?.selectedClass))
            {
                query = query.Where(x => x.FlightClass.Name.StartsWith(request.selectedClass));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Flights>>(query);
        }

        public List<Model.Flights> Recommend(int id)
        {
            //if (mLContext == null)
            //{

            //    mLContext = new MLContext();
            //    //var traindata = mlContext.Data.LoadFromTextFile(path: TrainingDataLocation,
            //    //                                                  columns: new[]
            //    //                                                            {
            //    //                                                    new TextLoader.Column("Label", DataKind.Single, 0),
            //    //                                                    new TextLoader.Column(name:nameof(ProductEntry.ProductID), dataKind:DataKind.UInt32, source: new [] { new TextLoader.Range(0) }, keyCount: new KeyCount(262111)),
            //    //                                                    new TextLoader.Column(name:nameof(ProductEntry.CoPurchaseProductID), dataKind:DataKind.UInt32, source: new [] { new TextLoader.Range(1) }, keyCount: new KeyCount(262111))
            //    //                                                            },
            //    //                                                  hasHeader: true,
            //    //                                                  separatorChar: '\t');

            //    var traindata = _context.SpecialOffers.Include(x=>x.Company).ToList();

            //    var data = new List<ProductEntry>();
            //    foreach (var x in traindata)
            //    {
            //        var distinctItem = x.Company.SpecialOffers.Select(x=>x.CompanyId).ToList();
            //    }

            //    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            //    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
            //    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
            //    options.LabelColumnName = "Label";
            //    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
            //    options.Alpha = 0.01;
            //    options.Lambda = 0.025;
            //    options.C = 0.00001;
            //    var est = mLContext.Recommendation().Trainers.MatrixFactorization(options);
            //    ITransformer model = est.Fit(traindata);
            //    var predictionengine = mLContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
            //    var prediction = predictionengine.Predict(
            //                             new ProductEntry()
            //                             {
            //                                 ProductID = 3,
            //                                 CoPurchaseProductID = 63
            //                             });
            //}
            return null;
        }
    }
}
