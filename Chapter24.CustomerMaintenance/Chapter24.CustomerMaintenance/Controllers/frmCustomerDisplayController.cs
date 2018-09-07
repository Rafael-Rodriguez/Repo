using System;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Perspectives;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class frmCustomerDisplayController
    {
        private ICustomerRepository _customerRepository;
        private object _syncLock = new object();

        public frmCustomerDisplayController(frmCustomerDisplay parentForm)
        {
            View = parentForm;
        }

        private frmCustomerDisplay View { get; set; }

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


        internal void GetCustomer(string customerIdText)
        {
            int customerID = Convert.ToInt32(customerIdText);
            GetCustomerByID(customerID);
        }

        internal void GetCustomerByID(int customerID)
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
    }
}
