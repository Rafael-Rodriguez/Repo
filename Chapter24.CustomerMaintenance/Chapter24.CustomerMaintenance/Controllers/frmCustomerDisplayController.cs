using System;
using System.Linq;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class frmCustomerDisplayController
    {
        private MMABooksEntities _dbContext;
        private object _syncLock = new object();

        public frmCustomerDisplayController(frmCustomerDisplay parentForm)
        {
            View = parentForm;
        }

        private frmCustomerDisplay View { get; set; }

        private MMABooksEntities DbContext
        {
            get
            {
                if(_dbContext == null)
                {
                    lock(_syncLock)
                    {
                        _dbContext = new MMABooksEntities();
                    }
                }

                return _dbContext;
            }
        }

        internal void GetCustomer(string customerIdText)
        {
            int customerID = Convert.ToInt32(customerIdText);
            GetCustomer(customerID);
        }

        private void GetCustomer(int customerID)
        {
            try
            {
                var matchingCustomer = DbContext.Customers.Where(customer => customer.CustomerID == customerID).SingleOrDefault();

                if (matchingCustomer == null)
                {
                    MessageBox.Show("No customer found with this ID." + "Please try again.", "Customer Not Found");
                    View.ClearControls();
                }
                else
                {
                    if (!DbContext.Entry(matchingCustomer).Reference("State").IsLoaded)
                    {
                        DbContext.Entry(matchingCustomer).Reference("State").Load();
                    }

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
