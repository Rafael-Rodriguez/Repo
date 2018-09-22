using System;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives;
using Chapter24.CustomerMaintenance.Perspectives.Components;
using Chapter24.CustomerMaintenance.Services;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class frmCustomerDisplayController : Controller<IfrmCustomerDisplay>
    {
        private ICustomerRepository _customerRepository;
        private object _syncLock = new object();
        private IMessageBox _messageBox;

        internal frmCustomerDisplayController(IfrmCustomerDisplay view, IModuleController moduleController)
            : base(moduleController)
        {
            View = view;
        }

        public frmCustomerDisplayController(IfrmCustomerDisplay view, ICustomerRepository customerRepository, IMessageBox messageBox, IModuleController moduleController)
            : base(moduleController)
        {
            View = view;
            _customerRepository = customerRepository;
            _messageBox = messageBox;
        }

        private ICustomerRepository CustomerRepository
        {
            get
            {
                if(_customerRepository == null)
                {
                    lock(_syncLock)
                    {
                        _customerRepository = new CustomerRepository();
                    }
                }

                return _customerRepository;
            }
        }

        private IMessageBox MessageBox
        {
            get
            {
                if(_messageBox == null)
                {
                    lock(_syncLock)
                    {
                        _messageBox = new MessageBox();
                    }
                }

                return _messageBox;
            }
        }


        public void DisplayCustomer(string customerIdText)
        {
            if(customerIdText == null)
            {
                throw new ArgumentNullException(nameof(customerIdText));
            }

            int customerID = Convert.ToInt32(customerIdText);

            DisplayCustomerByID(customerID);
        }

        public void DisplayCustomerByID(int customerID)
        {
            try
            {
                var matchingCustomer = CustomerRepository.GetCustomerById(customerID);

                if (matchingCustomer == null)
                {
                    MessageBox.Show("No customer found with this ID." + "Please try again.", "Customer Not Found");
                    View.ClearControls();
                }
                else
                {
                    View.DisplayCustomer(matchingCustomer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            var saveChangesResult = CustomerRepository.DeleteCustomer(customer);

            if(saveChangesResult.Value == SaveChangesResult.Result.Ok)
            {
                View.ClearControls();
            }
        }

        public void AddCustomer()
        {
            var programFlowManager = ModuleController.GetService<IProgramFlowManager>();
            Customer customerAdded = programFlowManager.AddNewCustomer();

            if(customerAdded != null)
            {
                DisplayCustomerByID(customerAdded.CustomerID);
            }
        }

        public void ModifyCustomer(Customer customer)
        {
            var programFlowManager = ModuleController.GetService<IProgramFlowManager>();
            Customer customerModified = programFlowManager.ModifyCustomer(customer);

            if (customerModified != null)
            {
                DisplayCustomerByID(customerModified.CustomerID);
            }
        }
    }
}
