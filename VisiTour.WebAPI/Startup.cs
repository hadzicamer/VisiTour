using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using VisiTour.Model;
using VisiTour.Model.Requests;
using VisiTour.WebAPI.Controllers;
using VisiTour.WebAPI.Database;
using VisiTour.WebAPI.Filters;
using VisiTour.WebAPI.Security;
using VisiTour.WebAPI.Services;

namespace VisiTour.WebAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(x => x.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });

            });
            services.AddDbContext<IB170172Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("visitourDB")).EnableSensitiveDataLogging());
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuth>("BasicAuthentication", null);

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ICRUDService<Model.Companies,CompaniesSearchRequest,CompaniesUpsertRequest, CompaniesUpsertRequest>,CompaniesService>();
            services.AddScoped<ICRUDService<Model.Payments, PaymentsSearchRequest, PaymentsUpsertRequest, PaymentsUpsertRequest>, PaymentsService>();
            services.AddScoped<ICRUDService<Model.Flights, FlightsSearchRequest, FlightsUpsertRequest, FlightsUpsertRequest>, FlightsService>();
            services.AddScoped<ICRUDService<Model.SpecialOffers, SpecialOffersSearchRequest, SpecialOffersUpsertRequest, SpecialOffersUpsertRequest>, SpecialOffersService>();
            //services.AddScoped<IService<Model.Cities, object>, BaseService<Model.Cities, object, Database.Cities>>();
            services.AddScoped<IService<Model.Countries, object>, BaseService<Model.Countries, object, Database.Countries>>();
            services.AddScoped<IService<Model.FlightStatus, object>, BaseService<Model.FlightStatus, object, Database.FlightStatus>>();
            services.AddScoped<IService<Model.FlightSeats, object>, BaseService<Model.FlightSeats, object, Database.FlightSeats>>();
            services.AddScoped<IService<Model.CreditCards, object>, BaseService<Model.CreditCards, object, Database.CreditCards>>();
            services.AddScoped<IService<Model.FlightClasses, object>, BaseService<Model.FlightClasses, object, Database.FlightClasses>>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<IBookingsService, BookingsService>();
            services.AddScoped<IRecommendService, RecommendService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ITitleService, TitleService>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ErrorFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });


            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
