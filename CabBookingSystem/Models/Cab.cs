using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CabBookingSystem.Models
{
    public partial class Cab
    {
        public Cab()
        {
            Booking = new HashSet<Booking>();
            Driver = new HashSet<Driver>();
        }

        public int Id { get; set; }
        public string CabId { get; set; }
        public string Cabname { get; set; }
        public string Cabtype { get; set; }
        public double? Fareperkm { get; set; }
        public int? CurrentLocation { get; set; }
        public bool? Isavailable { get; set; }

        public virtual Location CurrentLocationNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
    }
}
