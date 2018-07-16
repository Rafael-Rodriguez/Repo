using System;
using System.Windows.Forms;

namespace Chapter19.CustomerInvoices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                var customerID = Convert.ToInt32(customerIDToolStripTextBox.Text);
                this.customersTableAdapter.FillByCustomerID(this.mMABooksDataSet.Customers, customerID);
                this.invoicesTableAdapter.FillByCustomerID(this.mMABooksDataSet.Invoices, customerID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        /*private void fillByCustomerIDToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.invoicesTableAdapter.FillByCustomerID(this.mMABooksDataSet.Invoices, ((int)(System.Convert.ChangeType(customerIDToolStripTextBox1.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/
    }
}
