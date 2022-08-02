using CabBookingSystem.Models;
using CabBookingSystem.Repository;

namespace CabBookingSystem.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _cr;
        public CustomerService(ICustomerRepository cr)
        {
            _cr = cr;
        }

        public Customer Login(Customer user)
        {
            return _cr.Login(user);
            //throw new System.NotImplementedException();
        }

        public int Register(Customer user)
        {
            return _cr.Register(user);
           // throw new System.NotImplementedException();
        }
    }
}
