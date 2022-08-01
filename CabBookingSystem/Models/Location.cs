using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CabBookingSystem.Models
{
    public partial class Location
    {
        public Location()
        {
            Cab = new HashSet<Cab>();
            DistanceFromLocationNavigation = new HashSet<Distance>();
            DistanceToLocationNavigation = new HashSet<Distance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cab> Cab { get; set; }
        public virtual ICollection<Distance> DistanceFromLocationNavigation { get; set; }
        public virtual ICollection<Distance> DistanceToLocationNavigation { get; set; }
    }
}
