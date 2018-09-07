using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives
{
    public partial class frmCustomerDisplay : Form
    {
        private Customer selectedCustomer;

        public frmCustomerDisplay()
        {
            InitializeComponent();
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            if(txtBoxCustomerID.IsPresent() && txtBoxCustomerID.IsInt32())
            {
                int customerID = Convert.ToInt32(txtBoxCustomerID.Text);
                GetCustomer(customerID);
            }
        }

        private void GetCustomer(int customerID)
        {
            try
            {
                selectedCustomer = MMABooksEntity.mmaBooks.Customers.Where(customer => customer.CustomerID == customerID).Select(customer => customer).SingleOrDefault();

                if(selectedCustomer == null)
                {
                    MessageBox.Show("No customer found with this ID." + "Please try again.", "Customer Not Found");
                    ClearControls();
                    txtBoxCustomerID.Focus();
                }
                else
                {
                    if(!MMABooksEntity.mmaBooks.Entry(selectedCustomer).Reference("State").IsLoaded)
                    {
                        MMABooksEntity.mmaBooks.Entry(selectedCustomer).Reference("State").Load();
                    }

                    DisplayCustomer();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }

        private void DisplayCustomer()
        {
            txtBoxName.Text = selectedCustomer.Name;
            txtBoxAddress.Text = selectedCustomer.Address;
            txtBoxCity.Text = selectedCustomer.City;
            txtBoxState.Text = selectedCustomer.State.StateName;
            txtBoxZipCode.Text = selectedCustomer.ZipCode;

            btnModifyCustomer.Enabled = true;
            btnDeleteCustomer.Enabled = true;

        }

        private void ClearControls()
        {
            txtBoxName.Text = "";
            txtBoxAddress.Text = "";
            txtBoxCity.Text = "";
            txtBoxCustomerID.Text = "";
            txtBoxState.Text = "";
            txtBoxZipCode.Text = "";
            btnModifyCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
        }
    }
}
