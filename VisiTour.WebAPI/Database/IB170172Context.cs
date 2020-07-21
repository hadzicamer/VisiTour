using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VisiTour.WebAPI.Database
{
    public partial class IB170172Context : DbContext
    {
        public IB170172Context()
        {
        }

        public IB170172Context(DbContextOptions<IB170172Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CreditCards> CreditCards { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<FlightClasses> FlightClasses { get; set; }
        public virtual DbSet<FlightSeats> FlightSeats { get; set; }
        public virtual DbSet<FlightStatus> FlightStatus { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SpecialOffers> SpecialOffers { get; set; }
        public virtual DbSet<Title> Title { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=170172;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_LoginCust");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_BookingF");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.FoundingYear).HasMaxLength(50);

                entity.Property(e => e.Headquarter).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCards>(entity =>
            {
                entity.HasKey(e => e.CreditCardId)
                    .HasName("PK_Cards");

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(1000);

                entity.Property(e => e.PasswordSalt).HasMaxLength(1000);

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Customers__RoleI__71D1E811");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_Title");
            });

            modelBuilder.Entity<FlightClasses>(entity =>
            {
                entity.HasKey(e => e.FlightClassId)
                    .HasName("PK_Flight_class");

                entity.Property(e => e.FlightClassId).HasColumnName("FlightClassID");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<FlightSeats>(entity =>
            {
                entity.HasKey(e => e.FlightSeatId);

                entity.Property(e => e.FlightSeatId).HasColumnName("FlightSeatID");

                entity.Property(e => e.SeatNumber).HasMaxLength(2);
            });

            modelBuilder.Entity<FlightStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_Booking_status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.CityFromId).HasColumnName("CityFromID");

                entity.Property(e => e.CityToId).HasColumnName("CityToID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.FlightClassId).HasColumnName("FlightClassID");

                entity.Property(e => e.FlightSeatId).HasColumnName("FlightSeatID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.CityFrom)
                    .WithMany(p => p.FlightsCityFrom)
                    .HasForeignKey(d => d.CityFromId)
                    .HasConstraintName("FK_CityFrom");

                entity.HasOne(d => d.CityTo)
                    .WithMany(p => p.FlightsCityTo)
                    .HasForeignKey(d => d.CityToId)
                    .HasConstraintName("FK_CityTo");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Flights_Companies");

                entity.HasOne(d => d.FlightClass)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.FlightClassId)
                    .HasConstraintName("FK_FlightClasses");

                entity.HasOne(d => d.FlightSeat)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.FlightSeatId)
                    .HasConstraintName("FK_FlightSeats");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentMethod).HasMaxLength(10);

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CreditCardId)
                    .HasConstraintName("FK_CreditCardsP");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<SpecialOffers>(entity =>
            {
                entity.HasKey(e => e.OfferId);

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.CityFromId).HasColumnName("CityFromID");

                entity.Property(e => e.CityToId).HasColumnName("CityToID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.FlightClassId).HasColumnName("FlightClassID");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.CityFrom)
                    .WithMany(p => p.SpecialOffersCityFrom)
                    .HasForeignKey(d => d.CityFromId)
                    .HasConstraintName("FK_CityFromSO");

                entity.HasOne(d => d.CityTo)
                    .WithMany(p => p.SpecialOffersCityTo)
                    .HasForeignKey(d => d.CityToId)
                    .HasConstraintName("FK_CityToSO");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.SpecialOffers)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Flights_CompaniesS");

                entity.HasOne(d => d.FlightClass)
                    .WithMany(p => p.SpecialOffers)
                    .HasForeignKey(d => d.FlightClassId)
                    .HasConstraintName("FK_FlightClassS");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.Property(e => e.Name).HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
