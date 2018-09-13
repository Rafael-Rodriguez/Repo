using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Perspectives.Views
{
    public partial class frmAddCustomer : Form, IfrmAddCustomer, IView
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
                            _controller = new frmAddCustomerController(this);
                        }
                    }
                }

                return _controller;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {

        }
    }
}
