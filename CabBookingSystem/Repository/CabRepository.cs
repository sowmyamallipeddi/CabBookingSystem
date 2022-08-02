using CabBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CabBookingSystem.Repository
{
    public class CabRepository : ICabRepository
    {
        private readonly CabBookingContext _context;
        public CabRepository(CabBookingContext context)
        {
            _context = context;
        }

        public void bookCab(Booking booking)
        {
            _context.Booking.Add(booking);
            _context.SaveChanges();
            

            //throw new System.NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocations()
        {

            return _context.Location;
            //throw new System.NotImplementedException();
        }

        public ViewModel1 GetBooking(int id)
        {
            var result = (from b in _context.Booking
                         join c in _context.Cab on b.Cabid equals c.CabId
                         join d in _context.Driver on c.CabId equals d.Cabid
                         where b.Bookingid==id 
                         select new ViewModel1
                         {
                             Drivernumber = d.Mobile,
                             DriverName = d.Username,
                             OTP = b.Otp,
                             CabNo=c.CabNo,
                             BookingId = b.Bookingid

                         }).FirstOrDefault();
            return result;
        }

        public Cab GetCabbyid(int id)
        {
            return _context.Cab.Find(id);
            //throw new System.NotImplementedException();
        }

        public IEnumerable<Cab> GetCabs(int? fromlocation)
        {

            return _context.Cab.Where(x=>x.CurrentLocation==fromlocation && x.Isavailable==true);  
            //throw new System.NotImplementedException();
        }

        public Distance GetDistance(int? fromlocation, int? tolocation)
        {
            Distance result =(from j in _context.Distance
                         where j.FromLocation == fromlocation && j.ToLocation == tolocation
                         select j).FirstOrDefault();
            
            return  result;
        }

       
    }
}
