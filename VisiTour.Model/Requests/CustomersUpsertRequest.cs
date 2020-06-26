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
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [MinLength(3)]
        public string Country { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
