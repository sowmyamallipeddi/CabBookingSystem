using CabBookingSystem.Models;
using System.Collections.Generic;

namespace CabBookingSystem.Service
{
    public interface ICabService
    {

        public IEnumerable<Location> GetAllLocations();
        public Distance GetDistance(int? fromlocation, int? tolocation);
        public IEnumerable<Cab> GetCabs(int? fromlocation);
        void bookCab(Booking booking);
        Cab GetCabbyid(int id);
        ViewModel1 GetBooking(int id);
        IEnumerable<ViewModel2> GetBookinghistory(long mobileno);
        void UpdateRating(int id,Booking booking);
        Booking GetBookingid(int id);
    }
}
