using SRG_SYSTEM.Models;

namespace SRG_SYSTEM.DataAccess
{
    public interface ICustomerDataAccess
    {
        List<Customer> AccessCustomerDetails(int lastPageId);
    }
}