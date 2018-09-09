using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Perspectives
{
    public interface IfrmCustomerDisplay
    {
        void DisplayCustomer(Customer customer);

        void ClearControls();
    }
}
