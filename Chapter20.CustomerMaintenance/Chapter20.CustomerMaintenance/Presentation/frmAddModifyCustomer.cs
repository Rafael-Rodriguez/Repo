using Chapter20.CustomerMaintenance.Database;
using Chapter20.CustomerMaintenance.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Chapter20.CustomerMaintenance.Presentation
{
    public partial class frmAddModifyCustomer : Form
    {
        public bool AddCustomer { get; set; }

        public Customer Customer { get; set; }

        public frmAddModifyCustomer()
        {
            InitializeComponent();
        }

        private void frmAddModifyCustomer_Load(object sender, System.EventArgs e)
        {
            LoadStateComboBox();
        }

        private void LoadStateComboBox()
        {
            var states = StateRepository.GetStates();

            try
            {
                stateComboBox.DataSource = states;
                stateComboBox.DisplayMember = "StateName";
                stateComboBox.ValueMember = "StateCode";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if(AddCustomer)
                {
                    var customer = new Customer();

                    FillCustomerDataWithFields(customer);

                    try
                    {
                        InsertCustomerIntoDatabase(customer);

                        Customer = customer;

                        DialogResult = DialogResult.OK;
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
                else
                {
                }
            }
            else
            {
                var error = GetErrorInFields();
                MessageBox.Show($"Customer information is not valid. {error}", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetErrorInFields()
        {
            var error = string.Empty;

            if(!IsAlpha(nameTextBox.Text))
            {
                error += Properties.Resources.NameIsInvalid;
            }

            if(!IsAlphaNumeric(addressTextBox.Text))
            {
                error += Properties.Resources.AddressIsInvalid;
            }

            if(!IsAlpha(cityTextBox.Text))
            {
                error += Properties.Resources.CityIsInvalid;
            }

            if(!IsAlpha(stateComboBox.Text))
            {
                error += Properties.Resources.StateIsInvalid;
            }

            if(!IsNumeric(zipCodeTextBox.Text))
            {
                error += Properties.Resources.ZipCodeIsInvalid;
            }

            return error;
        }

        private void InsertCustomerIntoDatabase(Customer customer)
        {
            customer.CustomerID = CustomerRepository.AddCustomer(customer);
        }

        private void FillCustomerDataWithFields(Customer customer)
        {
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            customer.City = cityTextBox.Text;
            customer.State = stateComboBox.SelectedValue as string;
            customer.ZipCode = zipCodeTextBox.Text;
        }

        private bool IsValidData()
        {
            return  IsAlpha(nameTextBox.Text) &&
                    IsAlphaNumeric(addressTextBox.Text) &&
                    IsAlpha(cityTextBox.Text) &&
                    IsAlpha(stateComboBox.Text) &&
                    IsNumeric(zipCodeTextBox.Text);
        }

        private bool IsAlpha(string text)
        {
            if(string.IsNullOrEmpty(text))
            {
                return false;
            }

            Regex r = new Regex("^[a-zA-Z ]*$");
            if(r.IsMatch(text))
            {
                return true;
            }

            return false;
        }

        private bool IsNumeric(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            Regex r = new Regex("^[0-9]*$");
            if (r.IsMatch(text))
            {
                return true;
            }

            return false;
        }
        
        private bool IsAlphaNumeric(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            Regex r = new Regex("^[a-zA-Z0-9 ]*$");
            if (r.IsMatch(text))
            {
                return true;
            }

            return false;
        }

    }
}
