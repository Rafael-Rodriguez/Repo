using System.Collections.Generic;
using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.EventArgs;
using Chapter24.CustomerMaintenance.Perspectives.Views;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Perspectives
{
    public partial class frmModifyCustomer : Form, IfrmModifyCustomer
    {
        private IModuleController _moduleController;
        private frmModifyCustomerController _controller;
        private readonly object _syncLock = new object();

        public frmModifyCustomer(IModuleController controller)
        {
            _moduleController = controller;    
            InitializeComponent();
        }

        public Customer Customer { get; set; }

        public int CustomerID { get; set; }

        private frmModifyCustomerController Controller
        {
            get
            {
                if (_controller == null)
                {
                    lock (_syncLock)
                    {
                        if (_controller == null)
                        {
                            _controller = new frmModifyCustomerController(this, _moduleController);
                        }
                    }
                }

                return _controller;
            }

        }

        public void InitializeStateComboBox(List<State> states)
        {
            cboBoxState.DataSource = states;
            cboBoxState.DisplayMember = "StateName";
            cboBoxState.ValueMember = "StateCode";
        }

        public void DisplayCustomer(Customer customer)
        {
            txtBoxName.Text = customer.Name;
            txtBoxAddress.Text = customer.Address;
            txtBoxCity.Text = customer.City;
            cboBoxState.SelectedValue = customer.StateCode;
            txtBoxZipCode.Text = customer.ZipCode;
        }

        private void frmModifyCustomer_Load(object sender, System.EventArgs e)
        {
            Controller.OnLoad(CustomerID);
        }


    }
}
