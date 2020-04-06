using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Extensions;

namespace Chapter24.CustomerMaintenance.Perspectives.Views
{
    public partial class frmAddCustomer : Form, IfrmAddCustomer 
    {
        private IModuleController _moduleController;
        private frmAddCustomerController _controller;
        private readonly object _syncLock = new object();

        public frmAddCustomer(IModuleController moduleController)
        {
            _moduleController = moduleController;
            InitializeComponent();
        }

        public Customer Customer { get; set; }

        private frmAddCustomerController Controller
        {
            get
            {
                if(_controller == null)
                {
                    lock(_syncLock)
                    {
                        if(_controller == null)
                        {
                            _controller = new frmAddCustomerController(this, _moduleController);
                        }
                    }
                }

                return _controller;
            }

        }

        private void frmAddCustomer_Load(object sender, System.EventArgs e)
        {
            Controller.OnLoad();
        }

        public void InitializeStateComboBox(List<State> states)
        {
            cboBoxState.DataSource = states;
            cboBoxState.DisplayMember = "StateName";
            cboBoxState.ValueMember = "StateCode";
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            if(IsValidData())
            {
                Customer = new Customer();

                FillCustomerData(Customer);

                var result = Controller.AddCustomer(Customer);
                if(result)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorInvalidTextboxData);
            }
        }

        private void FillCustomerData(Customer customer)
        {
            customer.Name = txtBoxName.Text;
            customer.Address = txtBoxAddress.Text;
            customer.City = txtBoxCity.Text;
            customer.StateCode = cboBoxState.SelectedValue.ToString();
            customer.ZipCode = txtBoxZipCode.Text;
        }

        private bool IsValidData()
        {
            if(txtBoxName.IsAlphaOnly() && txtBoxAddress.IsAlphaNumericOnly() && txtBoxCity.IsAlphaOnly() && txtBoxZipCode.IsInt32())
            {
                return true;
            }

            return false;
        }

    }
}
