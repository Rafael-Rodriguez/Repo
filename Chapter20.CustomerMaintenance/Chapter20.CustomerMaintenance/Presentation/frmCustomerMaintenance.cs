using Chapter20.CustomerMaintenance.Database;
using Chapter20.CustomerMaintenance.Models;
using System;
using System.Windows.Forms;

namespace Chapter20.CustomerMaintenance.Presentation
{
    public partial class frmCustomerMaintenance : Form
    {
        public Customer Customer { get; set; }

        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private void buttonGetCustomer_Click(object sender, EventArgs e)
        {
            var customerIDText = customerIDTextBox.Text;

            if(!string.IsNullOrWhiteSpace(customerIDText))
            {
                int customerID = Convert.ToInt32(customerIDText);
                GetCustomer(customerID);
            }

        }

        private void GetCustomer(int customerID)
        {
            var customer = CustomerRepository.GetCustomer(customerID);
            if (customer == null)
            {
                MessageBox.Show(Properties.Resources.GetCustomerNoCustomerWithIDMessage, Properties.Resources.GetCustomerNoCustomerWithIDCaption);
                ClearControls();
            }
            else
            {
                DisplayCustomer(customer);
            }
        }

        private void DisplayCustomer(Customer customer)
        {
            nameTextBox.Text = customer.Name;
            addressTextBox.Text = customer.Address;
            cityTextBox.Text = customer.City;
            stateTextBox.Text = customer.State;
            zipCodeTextBox.Text = customer.ZipCode;

            Customer = customer;
        }

        private void ClearControls()
        {
            customerIDTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            cityTextBox.Text = "";
            stateTextBox.Text = "";
            zipCodeTextBox.Text = "";

            Customer = null;
        }

        private void OnLoad(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyCustomer addCustomerForm = new frmAddModifyCustomer();
            addCustomerForm.AddCustomer = true;

            DialogResult result = addCustomerForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                var customer = addCustomerForm.Customer;
                customerIDTextBox.Text = customer.CustomerID.ToString();
                DisplayCustomer(customer);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(Customer == null)
            {
                MessageBox.Show(Properties.Resources.ModifyCustomerNoCustomerFoundMessage, Properties.Resources.ModifyCustomerNoCustomerFoundCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddModifyCustomer modifyCustomerForm = new frmAddModifyCustomer();
            modifyCustomerForm.AddCustomer = false;
            modifyCustomerForm.Customer = Customer;

            DialogResult result = modifyCustomerForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                var customer = modifyCustomerForm.Customer;
                DisplayCustomer(customer);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Customer == null)
            {
                MessageBox.Show(Properties.Resources.DeleteCustomerNoCustomerFoundMessage, Properties.Resources.DeleteCustomerNoCustomerFoundCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var message = Properties.Resources.DeleteCustomerQuestion + " " + Customer.Name + " ?";
            DialogResult result = MessageBox.Show(message, Properties.Resources.DeleteCustomerCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.No)
            {
                return;
            }

            try
            {
                if(!CustomerRepository.DeleteCustomer(Customer))
                {
                    var deleteCustomerFailedMessage = Properties.Resources.DeleteCustomerFailedMessage + " " + Customer.Name + " .";
                    MessageBox.Show(deleteCustomerFailedMessage, Properties.Resources.DeleteCustomerFailedCaption);

                    GetCustomer(Customer.CustomerID);
                }
                else
                {
                    ClearControls();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }
    }
}
