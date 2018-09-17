using System.Collections.Generic;
using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;

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

        public void InitializeStateComboBox(List<State> list)
        {
            cboBoxState.DataSource = list;
            cboBoxState.DisplayMember = "StateName";
            cboBoxState.ValueMember = "StateCode";
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
