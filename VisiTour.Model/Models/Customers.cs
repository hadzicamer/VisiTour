using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Model
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }
    }
}
