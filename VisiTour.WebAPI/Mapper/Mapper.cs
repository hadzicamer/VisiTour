using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.Model.Requests;

namespace VisiTour.WebAPI.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
       
            CreateMap<Database.Customers, Model.Customers>();
            CreateMap<CustomersUpsertRequest,Database.Customers>();
            CreateMap<Database.Companies,Model.Companies>();
            CreateMap<CompaniesUpsertRequest,Database.Companies>();
            CreateMap<Database.Roles,Model.Roles>();
            CreateMap<Database.Payments, Model.Payments>();
            CreateMap<PaymentsUpsertRequest, Database.Payments>();
            CreateMap<Database.Flights, Model.Flights>();
            CreateMap<FlightsUpsertRequest, Database.Flights>();
            CreateMap<Database.Cities, Model.Cities>();
            CreateMap<Database.Countries, Model.Countries>();
            CreateMap<Database.FlightClasses, Model.FlightClasses>();
            CreateMap<Database.FlightSeats, Model.FlightSeats>();
            CreateMap<Database.Bookings, Model.Bookings>();
            CreateMap<Database.SpecialOffers, Model.SpecialOffers>();
            CreateMap<SpecialOffersUpsertRequest, Database.SpecialOffers>();
            CreateMap<Database.FlightStatus, Model.FlightStatus>();
            CreateMap<Database.FlightClasses, Model.FlightClasses>();
            CreateMap<Database.CreditCards, Model.CreditCards>();
        }
    }
}
