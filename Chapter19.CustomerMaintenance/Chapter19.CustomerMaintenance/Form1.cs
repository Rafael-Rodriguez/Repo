using System;
using System.Windows.Forms;

namespace Chapter19.CustomerMaintenance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mMABooksDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mMABooksDataSet.States' table. You can move, or remove it, as needed.
            this.statesTableAdapter.Fill(this.mMABooksDataSet.States);
        }

        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                var customerID = Convert.ToInt32(customerIDToolStripTextBox.Text);
                this.customersTableAdapter.FillByCustomerID(this.mMABooksDataSet.Customers, customerID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            customersTableAdapter.Fill(mMABooksDataSet.Customers);
        }
    }
}
