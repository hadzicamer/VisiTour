using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Roles
    {
        public Roles()
        {
            Customers = new HashSet<Customers>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
