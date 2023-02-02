using SRG_SYSTEM.Models;

namespace SRG_SYSTEM.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCountryList();
    }
}
