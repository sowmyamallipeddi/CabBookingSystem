using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CabBookingSystem.Models
{
    public partial class Booking
    {
        public int Bookingid { get; set; }
        public long? Mobileno { get; set; }
        public int? Cabid { get; set; }
        public double? Fare { get; set; }
        public double? Gst { get; set; }
        public int? DistanceId { get; set; }
        public int? Otp { get; set; }
        public decimal? TotalFare { get; set; }
        public string Status { get; set; }
        public double? Rating { get; set; }
        public DateTime? BookingDate { get; set; }

        public virtual Cab Cab { get; set; }
        public virtual Distance Distance { get; set; }
        public virtual Customer MobilenoNavigation { get; set; }
    }
}
