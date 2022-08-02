using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CabBookingSystem.Models
{
    public partial class Driver
    {
        public long Mobile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Licenseno { get; set; }
        public int? Cabid { get; set; }
        public bool? Isapproved { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Cab Cab { get; set; }
    }
}
