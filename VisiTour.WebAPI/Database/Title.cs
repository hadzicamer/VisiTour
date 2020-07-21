using System;
using System.Collections.Generic;

namespace VisiTour.WebAPI.Database
{
    public partial class Title
    {
        public Title()
        {
            Customers = new HashSet<Customers>();
        }

        public int TitleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
