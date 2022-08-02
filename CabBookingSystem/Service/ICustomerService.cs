using CabBookingSystem.Models;

namespace CabBookingSystem.Service
{
    public interface ICustomerService
    {
        int Register(Customer user);
        Customer Login(Customer user);
       
    }
}
