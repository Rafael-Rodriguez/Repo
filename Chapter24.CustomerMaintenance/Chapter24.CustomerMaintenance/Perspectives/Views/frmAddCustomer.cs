using System.Windows.Forms;
using Chapter24.CustomerMaintenance.Controllers;
using Chapter24.CustomerMaintenance.Model;

namespace Chapter24.CustomerMaintenance.Perspectives.Views
{
    public partial class frmAddCustomer : Form, IfrmAddCustomer
    {
        private IModuleController _moduleController;
        private frmAddCustomerController 

        public frmAddCustomer(IModuleController moduleController)
        {
            _moduleController = moduleController;
            InitializeComponent();
        }

        public Customer Customer { get; set; }


    }
}
