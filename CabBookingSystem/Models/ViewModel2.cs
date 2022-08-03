using System;

namespace CabBookingSystem.Models
{
    public class ViewModel2
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int BookingId { get; set; }
        public string CabNo { get; set; }
        public string DriverName { get; set; }
        public double? Fareperkm { get; set; }
        public double? Gst { get; set; }
        public decimal? TotalFare { get; set; }
        public DateTime? BookingDate { get; set; }
    }
}
