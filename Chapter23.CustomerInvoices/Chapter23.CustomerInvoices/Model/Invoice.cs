using System;

namespace Chapter23.CustomerInvoices.Model
{
    public class Invoice
    {
        public int InvoiceID { get; set; }

        public int CustomerID { get; set; }

        public DateTime InvoiceDate { get; set; }

        public float InvoiceTotal { get; set; }
    }
}
