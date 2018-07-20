using Chapter20.CustomerMaintenance.Models;
using Chapter20.CustomerMaintenance.Properties;
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
    }
}
