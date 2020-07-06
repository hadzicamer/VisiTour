﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisiTour.WebAPI.Database;

namespace VisiTour.WebAPI.Migrations
{
    [DbContext(typeof(IB170172Context))]
    [Migration("20200705191714_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VisiTour.WebAPI.Database.Bookings", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BookingID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnName("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("FlightId")
                        .HasColumnName("FlightID")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnName("PaymentID")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnName("StatusID")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FlightId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("StatusId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Cities", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CityID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Photo")
                        .HasColumnName("photo")
                        .HasColumnType("image");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Companies", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CompanyID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightClassId")
                        .HasColumnName("FlightClassID")
                        .HasColumnType("int");

                    b.Property<string>("FoundingYear")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Headquarter")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Photo")
                        .HasColumnName("photo")
                        .HasColumnType("image");

                    b.HasKey("CompanyId");

                    b.HasIndex("FlightClassId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Countries", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CountryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Flag")
                        .HasColumnName("flag")
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.CreditCards", b =>
                {
                    b.Property<int>("CreditCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CreditCardID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<byte[]>("Photo")
                        .HasColumnName("photo")
                        .HasColumnType("image");

                    b.HasKey("CreditCardId")
                        .HasName("PK_Cards");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CustomerID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CustomerId");

                    b.HasIndex("RoleId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.FlightClasses", b =>
                {
                    b.Property<int>("FlightClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FlightClassID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("FlightClassId")
                        .HasName("PK_Flight_class");

                    b.ToTable("FlightClasses");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.FlightSeats", b =>
                {
                    b.Property<int>("FlightSeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FlightSeatID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SeatNumber")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("FlightSeatId");

                    b.ToTable("FlightSeats");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.FlightStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StatusID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("StatusId")
                        .HasName("PK_Booking_status");

                    b.ToTable("FlightStatus");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Flights", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FlightID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityFromId")
                        .HasColumnName("CityFromID")
                        .HasColumnType("int");

                    b.Property<int?>("CityToId")
                        .HasColumnName("CityToID")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnName("CompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("date");

                    b.Property<int?>("FlightClassId")
                        .HasColumnName("FlightClassID")
                        .HasColumnType("int");

                    b.Property<int?>("FlightSeatId")
                        .HasColumnName("FlightSeatID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("FlightId");

                    b.HasIndex("CityFromId");

                    b.HasIndex("CityToId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FlightClassId");

                    b.HasIndex("FlightSeatId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Payments", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PaymentID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("money");

                    b.Property<int?>("CreditCardId")
                        .HasColumnName("CreditCardID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("PaymentId");

                    b.HasIndex("CreditCardId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.SpecialOffers", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OfferID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityFromId")
                        .HasColumnName("CityFromID")
                        .HasColumnType("int");

                    b.Property<int?>("CityToId")
                        .HasColumnName("CityToID")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnName("CompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("date");

                    b.Property<int?>("FlightClassId")
                        .HasColumnName("FlightClassID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("OfferId");

                    b.HasIndex("CityFromId");

                    b.HasIndex("CityToId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FlightClassId");

                    b.ToTable("SpecialOffers");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Bookings", b =>
                {
                    b.HasOne("VisiTour.WebAPI.Database.Customers", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Bookings_Customer");

                    b.HasOne("VisiTour.WebAPI.Database.Flights", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("FlightId")
                        .HasConstraintName("FK_FlightB");

                    b.HasOne("VisiTour.WebAPI.Database.Payments", "Payment")
                        .WithMany("Bookings")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK_Payments");

                    b.HasOne("VisiTour.WebAPI.Database.FlightStatus", "Status")
                        .WithMany("Bookings")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_Booking_status");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Companies", b =>
                {
                    b.HasOne("VisiTour.WebAPI.Database.FlightClasses", "FlightClass")
                        .WithMany("Companies")
                        .HasForeignKey("FlightClassId")
                        .HasConstraintName("FK_FlightClassC");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Customers", b =>
                {
                    b.HasOne("VisiTour.WebAPI.Database.Roles", "Role")
                        .WithMany("Customers")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Customers__RoleI__71D1E811");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Flights", b =>
                {
                    b.HasOne("VisiTour.WebAPI.Database.Cities", "CityFrom")
                        .WithMany("FlightsCityFrom")
                        .HasForeignKey("CityFromId")
                        .HasConstraintName("FK_CityFrom");

                    b.HasOne("VisiTour.WebAPI.Database.Cities", "CityTo")
                        .WithMany("FlightsCityTo")
                        .HasForeignKey("CityToId")
                        .HasConstraintName("FK_CityTo");

                    b.HasOne("VisiTour.WebAPI.Database.Companies", "Company")
                        .WithMany("Flights")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_Flights_Companies");

                    b.HasOne("VisiTour.WebAPI.Database.FlightClasses", "FlightClass")
                        .WithMany("Flights")
                        .HasForeignKey("FlightClassId")
                        .HasConstraintName("FK_FlightClasses");

                    b.HasOne("VisiTour.WebAPI.Database.FlightSeats", "FlightSeat")
                        .WithMany("Flights")
                        .HasForeignKey("FlightSeatId")
                        .HasConstraintName("FK_FlightSeats");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.Payments", b =>
                {
                    b.HasOne("VisiTour.WebAPI.Database.CreditCards", "CreditCard")
                        .WithMany("Payments")
                        .HasForeignKey("CreditCardId")
                        .HasConstraintName("FK_CreditCardsP");
                });

            modelBuilder.Entity("VisiTour.WebAPI.Database.SpecialOffers", b =>
                {
                    b.HasOne("VisiTour.WebAPI.Database.Cities", "CityFrom")
                        .WithMany("SpecialOffersCityFrom")
                        .HasForeignKey("CityFromId")
                        .HasConstraintName("FK_CityFromSO");

                    b.HasOne("VisiTour.WebAPI.Database.Cities", "CityTo")
                        .WithMany("SpecialOffersCityTo")
                        .HasForeignKey("CityToId")
                        .HasConstraintName("FK_CityToSO");

                    b.HasOne("VisiTour.WebAPI.Database.Companies", "Company")
                        .WithMany("SpecialOffers")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_Flights_CompaniesS");

                    b.HasOne("VisiTour.WebAPI.Database.FlightClasses", "FlightClass")
                        .WithMany("SpecialOffers")
                        .HasForeignKey("FlightClassId")
                        .HasConstraintName("FK_FlightClassS");
                });
#pragma warning restore 612, 618
        }
    }
}
