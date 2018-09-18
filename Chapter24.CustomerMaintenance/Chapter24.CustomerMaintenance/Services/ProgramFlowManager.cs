using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;
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
                return addCustomerForm.Customer;
            }

            return null;
        }

        public Customer ModifyCustomer(Customer customer)
        {
            var modifyCustomerForm = _moduleController.GetView<IfrmModifyCustomer>();
            modifyCustomerForm.Customer = customer;
            var dialogResult = modifyCustomerForm.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                return modifyCustomerForm.Customer;
            }

            return null;
        }
    }
}
