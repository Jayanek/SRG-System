using SRG_SYSTEM.DataAccess;
using SRG_SYSTEM.Models;

namespace SRG_SYSTEM.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerDataAccess _customerDataAccess;

        public CustomerRepository(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public List<Customer> GetCustomerList(int lastPageId)
        {

            return _customerDataAccess.AccessCustomerDetails(lastPageId);

        }
    }
}
