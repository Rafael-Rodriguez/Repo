using Chapter24.CustomerMaintenance.Perspectives.Extensions;
using System;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance.Perspectives
{
    public partial class frmCustomerDisplay : Form
    {
        public frmCustomerDisplay()
        {
            InitializeComponent();
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            if(txtBoxCustomerID.IsPresent() && txtBoxCustomerID.IsInt32())
            {
                int customerID = Convert.ToInt32(txtBoxCustomerID.Text);
            }
        }
    }
}
