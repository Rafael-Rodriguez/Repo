using Chapter24.CustomerMaintenance.Controllers;
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

        public void AddNewCustomer()
        {
            var addCustomerForm = _moduleController.GetView<IfrmAddCustomer>();
            addCustomerForm.Customer = null;
            var dialogResult = addCustomerForm.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                var customerDisplayForm = _moduleController.GetView<IfrmCustomerDisplay>();
                customerDisplayForm.DisplayCustomer(addCustomerForm.Customer);
            }
        }
    }
}
