using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Database
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerID);

        bool AddCustomer(Customer customer);

        SaveChangesResult SaveChanges(Customer customer);

        SaveChangesResult DeleteCustomer(Customer customer);
    }
}