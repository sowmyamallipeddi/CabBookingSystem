using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CabBookingSystem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Booking = new HashSet<Booking>();
        }

        public long Mobile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
