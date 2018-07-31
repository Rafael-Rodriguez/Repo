namespace Chapter23.CustomerInvoices
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewCustomerInvoices = new System.Windows.Forms.ListView();
            this.columnCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnInvoiceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnInvoiceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnInvoiceTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewCustomerInvoices
            // 
            this.listViewCustomerInvoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnCustomer,
            this.columnInvoiceID,
            this.columnInvoiceDate,
            this.columnInvoiceTotal});
            this.listViewCustomerInvoices.Location = new System.Drawing.Point(13, 13);
            this.listViewCustomerInvoices.Name = "listViewCustomerInvoices";
            this.listViewCustomerInvoices.Size = new System.Drawing.Size(510, 425);
            this.listViewCustomerInvoices.TabIndex = 0;
            this.listViewCustomerInvoices.UseCompatibleStateImageBehavior = false;
            this.listViewCustomerInvoices.View = System.Windows.Forms.View.Details;
            // 
            // columnCustomer
            // 
            this.columnCustomer.Text = "Customer";
            this.columnCustomer.Width = 149;
            // 
            // columnInvoiceID
            // 
            this.columnInvoiceID.Text = "InvoiceID";
            this.columnInvoiceID.Width = 89;
            // 
            // columnInvoiceDate
            // 
            this.columnInvoiceDate.Text = "Invoice Date";
            this.columnInvoiceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnInvoiceDate.Width = 143;
            // 
            // columnInvoiceTotal
            // 
            this.columnInvoiceTotal.Text = "Invoice Total";
            this.columnInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnInvoiceTotal.Width = 90;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 450);
            this.Controls.Add(this.listViewCustomerInvoices);
            this.Name = "Form1";
            this.Text = "Customer Invoices By Invoice Total";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewCustomerInvoices;
        private System.Windows.Forms.ColumnHeader columnCustomer;
        private System.Windows.Forms.ColumnHeader columnInvoiceID;
        private System.Windows.Forms.ColumnHeader columnInvoiceDate;
        private System.Windows.Forms.ColumnHeader columnInvoiceTotal;
    }
}

