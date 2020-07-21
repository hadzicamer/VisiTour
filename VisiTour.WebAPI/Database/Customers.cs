using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Customers
    {
        public Customers()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Country { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public int? TitleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Title Title { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
