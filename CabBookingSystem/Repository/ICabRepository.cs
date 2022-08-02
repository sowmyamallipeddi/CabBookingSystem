using CabBookingSystem.Models;
using System.Collections.Generic;

namespace CabBookingSystem.Repository
{
    public interface ICabRepository
    {
        public IEnumerable<Location> GetAllLocations();

        public Distance GetDistance(int? fromlocation, int? tolocation);

        public IEnumerable<Cab> GetCabs(int? fromlocation);
        void bookCab(Booking booking);

        Cab GetCabbyid(int id);

        ViewModel1 GetBooking(int id);
    }
}
