using System.Collections.Generic;
using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Perspectives.Views;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Database;
using Chapter24.CustomerMaintenance.Model;
using Chapter24.CustomerMaintenance.Perspectives.Extensions;

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
            Controller.OnLoad(Customer);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            if (IsValidData())
            {
                UpdateCustomer();

                var result = Controller.ModifyCustomer(Customer);

                if (result.Value == SaveChangesResult.Result.Ok)
                {
                    DialogResult = DialogResult.OK;
                }
                else if (result.Value == SaveChangesResult.Result.Abort)
                {
                    MessageBox.Show(Properties.Resources.ErrorUnableToSaveCustomerAnotherUserHasDeleted);
                    DialogResult = DialogResult.Abort;
                }
                else if (result.Value == SaveChangesResult.Result.Retry)
                {
                    MessageBox.Show(Properties.Resources.ErrorUnableToSaveCustomerAnotherUserHasModified);
                    DialogResult = DialogResult.Retry;
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorInvalidTextboxData);
            }
        }

        private void UpdateCustomer()
        {
            Customer.Name = txtBoxName.Text;
            Customer.Address = txtBoxAddress.Text;
            Customer.City = txtBoxCity.Text;
            Customer.StateCode = cboBoxState.SelectedValue.ToString();
            Customer.ZipCode = txtBoxZipCode.Text;
        }

        private bool IsValidData()
        {
            if (txtBoxName.IsAlphaOnly() && txtBoxAddress.IsAlphaNumericOnly() && txtBoxCity.IsAlphaOnly() && txtBoxZipCode.IsInt32())
            {
                return true;
            }

            return false;
        }
    }
}
