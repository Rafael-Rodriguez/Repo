namespace Chapter24.CustomerMaintenance.Controllers
{
    public interface IfrmCustomerDisplayController
    {
        void DisplayCustomer(string customerIdText);

        void DisplayCustomerByID(int customerID);
    }
}
