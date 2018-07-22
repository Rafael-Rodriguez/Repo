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

            if(customerIDText != null)
            {
                int customerID = Convert.ToInt32(customerIDText);

                var customer = CustomerRepository.GetCustomer(customerID);
                if(customer == null)
                {
                    MessageBox.Show(Properties.Resources.GetCustomerNoCustomerWithIDMessage, Properties.Resources.GetCustomerNoCustomerWithIDCaption);
                    ClearControls();
                }
                else
                {
                    DisplayCustomer(customer);
                }
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
    }
}
