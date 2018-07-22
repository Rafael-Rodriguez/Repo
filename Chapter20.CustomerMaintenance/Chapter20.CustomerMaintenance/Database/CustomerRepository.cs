using Chapter20.CustomerMaintenance.Models;
using Chapter20.CustomerMaintenance.Properties;
using System;
using System.Data.SqlClient;

namespace Chapter20.CustomerMaintenance.Database
{
    public static class CustomerRepository
    {
        public static Customer GetCustomer(int customerID)
        {
            var connection = new SqlConnection(Settings.Default.MMABooksConnectionString);
            var selectStatement =    "SELECT CustomerID, Name, Address, City, State, ZipCode " +
                                        "FROM Customers " +
                                        "WHERE CustomerID = @CustomerID";

            var selectCommand = new SqlCommand(selectStatement, connection);

            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);

            try
            {
                connection.Open();
                var customerReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if(customerReader.Read())
                {
                    var customer = new Customer
                    {
                        CustomerID = (int)customerReader["CustomerID"],
                        Name = customerReader["Name"].ToString(),
                        Address = customerReader["Address"].ToString(),
                        City = customerReader["City"].ToString(),
                        State = customerReader["State"].ToString(),
                        ZipCode = customerReader["ZipCode"].ToString()
                    };

                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int AddCustomer(Customer customer)
        {
            var connection = new SqlConnection(Settings.Default.MMABooksConnectionString);
            var insertStatement = "INSERT INTO Customers (Name, Address, City, State, ZipCode) " +
                                    "VALUES (@Name, @Address, @City, @State, @ZipCode)";

            var insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@Name", customer.Name);
            insertCommand.Parameters.AddWithValue("@Address", customer.Address);
            insertCommand.Parameters.AddWithValue("@City", customer.City);
            insertCommand.Parameters.AddWithValue("@State", customer.State);
            insertCommand.Parameters.AddWithValue("@ZipCode", customer.ZipCode);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();

                string selectStatement = "SELECT IDENT_CURRENT('Customers') FROM Customers";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
