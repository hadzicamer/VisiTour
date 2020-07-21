using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VisiTour.WebAPI.Additionals;

namespace VisiTour.WebAPI.Database
{
    public partial class IB170172Context
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles()
            {
                RoleId = 1,
                Name = "Administrator"
            });

            modelBuilder.Entity<Roles>().HasData(new Roles()
            {
                RoleId = 2,
                Name = "User"
            });
            
            // admin
            Customers c1 = new Customers
            {
                CustomerId = 1,
                RoleId=1,
                Name = "admin",
                Username = "desktop",
                Country = "Bosnia",
                DateOfBirth = new DateTime(2000, 1, 1),
                Email = "admin@mail.com",
            };
            c1.PasswordSalt = HashSaltGen.GenerateSalt(); 
            c1.PasswordHash = HashSaltGen.GenerateHash(c1.PasswordSalt, "test");
            modelBuilder.Entity<Customers>().HasData(c1);

            // mobile user
            Customers c2 = new Customers
            {
                CustomerId = 2,
                RoleId=2,
                Name = "mobile",
                Username = "mobile",
                Country = "USA",
                DateOfBirth = new DateTime(2000, 2, 3),
                Email = "mobile@mail.com",
            };
            c2.PasswordSalt = HashSaltGen.GenerateSalt();
            c2.PasswordHash = HashSaltGen.GenerateHash(c2.PasswordSalt, "test");
            modelBuilder.Entity<Customers>().HasData(c2);

            //modelBuilder.Entity<Bookings>().HasData(new Bookings()
            //{
            //    BookingId = 1,
            //    Details = "Flight Sarajevo- London on Thursday 21. of May at 12:00"
            //});

            //Cities

            modelBuilder.Entity<Cities>().HasData(new Cities()
            {
                CityId = 1,
                Name = "Sarajevo"
            });

            modelBuilder.Entity<Cities>().HasData(new Cities()
            {
                CityId = 2,
                Name = "London"
            });
            modelBuilder.Entity<Cities>().HasData(new Cities()
            {
                CityId = 3,
                Name = "Paris"
            });
            modelBuilder.Entity<Cities>().HasData(new Cities()
            {
                CityId = 4,
                Name = "Oslo"
            });
            modelBuilder.Entity<Cities>().HasData(new Cities()
            {
                CityId = 5,
                Name = "Prague"
            });
            modelBuilder.Entity<Cities>().HasData(new Cities()
            {
                CityId = 6,
                Name = "Istanbul"
            });

            //Countries
            modelBuilder.Entity<Countries>().HasData(new Countries()
            {
                CountryId = 1,
                Name = "BiH"
            });

            modelBuilder.Entity<Countries>().HasData(new Countries()
            {
                CountryId = 2,
                Name = "USA"
            });

            //Companies
            Companies co1 = new Companies
            {
                CompanyId = 1,
                Name = "Turkish Airlines",
                Headquarter = "Istanbul",
                FoundingYear = "1933.",
                Photo = File.ReadAllBytes("img/turkishAirlines.png"),
            };

            modelBuilder.Entity<Companies>().HasData(co1);

            Companies co2 = new Companies
            {
                CompanyId = 2,
                Name = "FlyBosnia",
                Headquarter = "Sarajevo",
                FoundingYear = "2017.",
               Photo = File.ReadAllBytes("img/flyBosnia.png"),
            };

            modelBuilder.Entity<Companies>().HasData(co2);

            Companies co3 = new Companies
            {
                CompanyId = 3,
                Name = "Lufthansa",
                Headquarter = "Köln",
                FoundingYear = "1953.",
                Photo = File.ReadAllBytes("img/lufthansa.png"),
            };

            modelBuilder.Entity<Companies>().HasData(co3);

            //CreditCards

            modelBuilder.Entity<CreditCards>().HasData(new CreditCards()
            {
                CreditCardId = 1,
                Name = "MasterCard"
            });

            modelBuilder.Entity<CreditCards>().HasData(new CreditCards()
            {
                CreditCardId = 2,
                Name = "Visa"
            });
            modelBuilder.Entity<CreditCards>().HasData(new CreditCards()
            {
                CreditCardId = 3,
                Name = "Amex"
            });

            //Flight classes

            modelBuilder.Entity<FlightClasses>().HasData(new FlightClasses()
            {
                FlightClassId = 1,
                Name = "Economy",
                Description = "Whether it’s a short flight or a long one – comfortable seats await you in Economy Class. There’s plenty of room both on short and medium - haul flights.Thanks to the slim construction of the backrests,our seating provides more legroom so that you can stretch your legs out comfortably when flying in Economy Class too.On long - haul flights,   the wide seat cushions measuring over 40 cm and the individually adjustable headrests on each seat ensure you’re comfortable."
            });

            modelBuilder.Entity<FlightClasses>().HasData(new FlightClasses()
            {
                FlightClassId = 2,
                Name = "Business",
                Description = "As a Business Class passenger, there is a wide selection of lounges available to you at all major international airports where you can relax, freshen up and, quite simply, feel good. In order to increase passengers’ sleeping time, an optimised night service is offered on short long-haul flights which depart after 20.00 hours and have a flight duration of six to eight hours. "
            });

            modelBuilder.Entity<FlightClasses>().HasData(new FlightClasses()
            {
                FlightClassId = 3,
                Name = "First",
                Description = "It’s often the details and the little things that can turn a moment into something really special. Being greeted by a personal assistant at your destination airport, culinary highlights above the clouds or the personal space on board: moments that linger in the memory. With our First Class, we shape your travel experience with great attention to detail and with your personal wishes in mind. Enjoy excellent comfort and service and experience your very own special moments in our First Class."
            });

            Flights f1 = new Flights
            {
                FlightId = 1,
                CityFromId = 1,
                DateFrom = new DateTime(2018, 1, 1),
                CityToId = 3,
                DateTo = new DateTime(2018, 1, 20),
                Price = 200,
                FlightClassId = 2,
                //FlightSeatId = 11,

            };

            modelBuilder.Entity<Flights>().HasData(f1);

            Flights f2 = new Flights
            {
                FlightId = 2,
                CityFromId = 5,
                DateFrom = new DateTime(2020, 4, 1),
                CityToId = 2,
                DateTo = new DateTime(2020, 4, 26),
                Price = 300,
                FlightClassId = 1,
                //FlightSeatId = 7,
            };

            modelBuilder.Entity<Flights>().HasData(f2);

            Flights f3 = new Flights
            {
                FlightId = 3,
                CityFromId = 1,
                DateFrom = new DateTime(2020, 6, 14),
                CityToId = 6,
                DateTo = new DateTime(2020, 7, 1),
                Price = 150,
                FlightClassId = 3,
                //FlightSeatId = 1,
            };

            modelBuilder.Entity<Flights>().HasData(f3);



            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 1,
            //    SeatNumber = "1."
            //});

            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 2,
            //    SeatNumber = "2."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 3,
            //    SeatNumber = "3."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 4,
            //    SeatNumber = "4."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 5,
            //    SeatNumber = "5."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 6,
            //    SeatNumber = "6."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 7,
            //    SeatNumber = "7."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 8,
            //    SeatNumber = "8."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 9,
            //    SeatNumber = "9."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 10,
            //    SeatNumber = "10."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 11,
            //    SeatNumber = "11."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 12,
            //    SeatNumber = "12."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 13,
            //    SeatNumber = "13."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 14,
            //    SeatNumber = "14."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 15,
            //    SeatNumber = "15."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 16,
            //    SeatNumber = "16."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 17,
            //    SeatNumber = "17."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 18,
            //    SeatNumber = "18."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 19,
            //    SeatNumber = "19."
            //});
            //modelBuilder.Entity<FlightSeats>().HasData(new FlightSeats()
            //{
            //    FlightSeatId = 20,
            //    SeatNumber = "20."
            //});

            //flight status

            modelBuilder.Entity<FlightStatus>().HasData(new FlightStatus()
            {
                StatusId = 1,
                StatusDescription = "Active"
            });

            modelBuilder.Entity<FlightStatus>().HasData(new FlightStatus()
            {
                StatusId = 2,
                StatusDescription = "Suspended"
            });
            modelBuilder.Entity<FlightStatus>().HasData(new FlightStatus()
            {
                StatusId = 3,
                StatusDescription = "Canceled"
            });
            modelBuilder.Entity<FlightStatus>().HasData(new FlightStatus()
            {
                StatusId = 4,
                StatusDescription = "Closed"
            });

            //payments
            Payments p1 = new Payments
            {
                PaymentId = 1,
                PaymentDate = new DateTime(2020, 6, 14),
                Amount = 200,
                PaymentMethod = "Card",
                CreditCardId = 2,
            };
            modelBuilder.Entity<Payments>().HasData(p1);

            Payments p2 = new Payments
            {
                PaymentId = 2,
                PaymentDate = new DateTime(2020, 7, 14),
                Amount = 200,
                PaymentMethod = "Cash",
                CreditCardId = null,
            };
            modelBuilder.Entity<Payments>().HasData(p2);

            //Special offers
            SpecialOffers s1 = new SpecialOffers
            {
                OfferId = 1,
                CityFromId = 4,
                DateFrom = new DateTime(2020, 6, 14),
                CityToId = 2,
                DateTo = new DateTime(2020, 6, 20),
                Price = 500,
                CompanyId=2,
                FlightClassId = 1,
              
            };
            modelBuilder.Entity<SpecialOffers>().HasData(s1);

            SpecialOffers s2 = new SpecialOffers
            {
                OfferId = 2,
                CityFromId = 3,
                DateFrom = new DateTime(2020, 7, 14),
                CityToId = 5,
                DateTo = new DateTime(2020, 7, 20),
                Price = 400,
                CompanyId = 3,
                FlightClassId = 2,
             
            };
            modelBuilder.Entity<SpecialOffers>().HasData(s2);

            SpecialOffers s3 = new SpecialOffers
            {
                OfferId = 3,
                CityFromId = 2,
                DateFrom = new DateTime(2020, 8, 20),
                CityToId = 4,
                DateTo = new DateTime(2020, 9, 1),
                Price = 100,
                CompanyId = 2,
                FlightClassId = 1,
           
            };
            modelBuilder.Entity<SpecialOffers>().HasData(s3);
        }
    }
}
