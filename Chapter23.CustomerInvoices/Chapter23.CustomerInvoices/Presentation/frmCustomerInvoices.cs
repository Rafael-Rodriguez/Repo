using Chapter23.CustomerInvoices.Database;
using Chapter23.CustomerInvoices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chapter23.CustomerInvoices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var customers = CustomerRepository.GetCustomers();
            var invoices = InvoiceRepository.GetInvoices();

            var customerInvoices = from invoice in invoices
                                   join customer in customers
                                   on invoice.CustomerID equals customer.CustomerID
                                   orderby customer.Name, invoice.InvoiceTotal descending
                                   select new
                                   {
                                       customer.Name,
                                       invoice.InvoiceID,
                                       invoice.InvoiceDate,
                                       invoice.InvoiceTotal
                                   };

            foreach(var invoice in customerInvoices)
            {
                var listViewItem = listViewCustomerInvoices.Items.Add(invoice.Name);
                listViewItem.SubItems.Add(invoice.InvoiceID.ToString());
                listViewItem.SubItems.Add(invoice.InvoiceDate.ToString());
                listViewItem.SubItems.Add(invoice.InvoiceTotal.ToString("c"));
            }
        }
    }
}
