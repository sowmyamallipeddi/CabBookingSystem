using CabBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;
namespace CabBookingSystem.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CabBookingContext _db;
        public CustomerRepository(CabBookingContext db)
        {
            _db = db;
        }
        public Customer Login(Customer user)
        {
            var result = _db.Customer.FirstOrDefault(x => x.Mobile==user.Mobile && x.Password==user.Password);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
            //throw new System.NotImplementedException();
        }

        public int Register(Customer user)
        {
            var result = _db.Customer.FirstOrDefault(x => x.Mobile == user.Mobile);
            if (result == null)
            {
                _db.Customer.Add(user);
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
            //throw new System.NotImplementedException();
        }
        



    }
}
