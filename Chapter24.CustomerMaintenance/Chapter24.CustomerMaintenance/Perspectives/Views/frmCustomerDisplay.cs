using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Extensions;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives
{
    public partial class frmCustomerDisplay : Form, IfrmCustomerDisplay
    {
        private frmCustomerDisplayController _controller;
        private readonly object _syncLock = new object();
        private IModuleController _moduleController;

        public frmCustomerDisplay(IModuleController controller)
        {
            _moduleController = controller;

            InitializeComponent();
        }

        private frmCustomerDisplayController Controller
        {
            get
            {
                if(_controller == null)
                {
                    lock(_syncLock)
                    {
                        _controller = new frmCustomerDisplayController(this,_moduleController);
                    }
                }

                return _controller;
            }
        }

        private void btnGetCustomer_Click(object sender, System.EventArgs e)
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

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAddCustomer_Click(object sender, System.EventArgs e)
        {
            Controller.AddCustomer();
        }
    }
}
