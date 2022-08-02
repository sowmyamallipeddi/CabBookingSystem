using CabBookingSystem.Models;

namespace CabBookingSystem.Repository
{
    public interface ICustomerRepository
    {
        int Register(Customer user);
       Customer Login(Customer user);
    }
}
