using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Database
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerID);
    }
}