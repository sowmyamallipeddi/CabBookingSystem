using CabBookingSystem.Models;
using CabBookingSystem.Repository;
using System.Collections.Generic;

namespace CabBookingSystem.Service
{
    public class CabService : ICabService
    {
        private readonly ICabRepository _irepo;
        public CabService(ICabRepository irepo)
        {
            _irepo = irepo;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _irepo.GetAllLocations();
            //throw new System.NotImplementedException();
        }

        public IEnumerable<Cab> GetCabs(int? fromlocation)
        {
            return _irepo.GetCabs(fromlocation);
            //throw new System.NotImplementedException();
        }

        public Distance GetDistance(int? fromlocation, int? tolocation) { 
        return _irepo.GetDistance(fromlocation, tolocation);
        }

        

        public void bookCab(Booking booking)
        {
            _irepo.bookCab(booking);
        }

        public Cab GetCabbyid(int id)
        {
            return _irepo.GetCabbyid(id);
            //throw new System.NotImplementedException();
        }

        public ViewModel1 GetBooking(int id)
        {
            return _irepo.GetBooking(id);
        }

        public IEnumerable<ViewModel2> GetBookinghistory(long mobileno)
        {
            return _irepo.GetBookinghistory(mobileno);
           // throw new System.NotImplementedException();
        }
    }
}
