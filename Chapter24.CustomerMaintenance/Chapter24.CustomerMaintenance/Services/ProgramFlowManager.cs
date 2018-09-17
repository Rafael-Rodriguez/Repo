using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives;
using Chapter24.CustomerMaintenance.Perspectives.Views;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Services
{
    public class ProgramFlowManager : IProgramFlowManager
    {
        private readonly IModuleController _moduleController;

        public ProgramFlowManager(IModuleController moduleController)
        {
            _moduleController = moduleController;
        }

        public Customer AddNewCustomer()
        {
            var addCustomerForm = _moduleController.GetView<IfrmAddCustomer>();
            addCustomerForm.Customer = null;
            var dialogResult = addCustomerForm.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                //return true;
                //var customerDisplayForm = _moduleController.GetView<IfrmCustomerDisplay>();
                //customerDisplayForm.DisplayCustomer(addCustomerForm.Customer);

                return addCustomerForm.Customer;
            }

            return null;
        }
    }
}
