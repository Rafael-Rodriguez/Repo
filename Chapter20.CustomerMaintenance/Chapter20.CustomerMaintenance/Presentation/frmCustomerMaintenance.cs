using Chapter20.CustomerMaintenance.Database;
using Chapter20.CustomerMaintenance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter20.CustomerMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
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
        }

        private void ClearControls()
        {
            customerIDTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            cityTextBox.Text = "";
            stateTextBox.Text = "";
            zipCodeTextBox.Text = "";
        }

        private void OnLoad(object sender, EventArgs e)
        {

        }
    }
}
