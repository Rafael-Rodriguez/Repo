using Chapter20.CustomerMaintenance.Models;

namespace Chapter20.CustomerMaintenance.Database
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int customerID);
    }
}
