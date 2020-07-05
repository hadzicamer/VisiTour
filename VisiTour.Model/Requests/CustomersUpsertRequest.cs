using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VisiTour.Model.Requests
{
    public class CustomersUpsertRequest
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Country { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
