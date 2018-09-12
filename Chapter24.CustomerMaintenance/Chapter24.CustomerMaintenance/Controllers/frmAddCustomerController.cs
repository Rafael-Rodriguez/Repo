using Chapter24.CustomerMaintenance.Perspectives.Views;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class frmAddCustomerController
    {
        private IfrmAddCustomer _view;

        internal frmAddCustomerController(IfrmAddCustomer view)
        {
            _view = view;
        }
    }
}
