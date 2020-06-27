using System;
using System.Collections.Generic;
using System.Text;

namespace VisiTour.Mobile.Models
{
    public enum MenuItemType
    {
        Home,
        Profile,
        FindFlights,
        Classes,
        Offers
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
