using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CabBookingSystem.Models
{
    public partial class Distance
    {
        public Distance()
        {
            Booking = new HashSet<Booking>();
        }

        public int DistanceId { get; set; }
        public int? FromLocation { get; set; }
        public int? ToLocation { get; set; }
        public double? Distanceinkm { get; set; }

        public virtual Location FromLocationNavigation { get; set; }
        public virtual Location ToLocationNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
