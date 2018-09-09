using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Extensions;
using System;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives
{
    public partial class frmCustomerDisplay : Form, IfrmCustomerDisplay
    {
        private IfrmCustomerDisplayController _controller;
        private object _syncLock = new object();

        public frmCustomerDisplay()
        {
            InitializeComponent();
        }

        private IfrmCustomerDisplayController Controller
        {
            get
            {
                if(_controller == null)
                {
                    lock(_syncLock)
                    {
                        _controller = new frmCustomerDisplayController(this);
                    }
                }

                return _controller;
            }
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            if(txtBoxCustomerID.IsPresent() && txtBoxCustomerID.IsInt32())
            {
                Controller.DisplayCustomer(txtBoxCustomerID.Text);
            }
        }

        public void DisplayCustomer(Customer customer)
        {
            txtBoxName.Text = customer.Name;
            txtBoxAddress.Text = customer.Address;
            txtBoxCity.Text = customer.City;
            txtBoxState.Text = customer.State.StateName;
            txtBoxZipCode.Text = customer.ZipCode;

            btnModifyCustomer.Enabled = true;
            btnDeleteCustomer.Enabled = true;
        }

        public void ClearControls()
        {
            txtBoxName.Text = "";
            txtBoxAddress.Text = "";
            txtBoxCity.Text = "";
            txtBoxCustomerID.Text = "";
            txtBoxState.Text = "";
            txtBoxZipCode.Text = "";

            txtBoxCustomerID.Focus();

            btnModifyCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
        }
    }
}
