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
            using (var connection = new SqlConnection(Settings.Default.MMABooksConnectionString))
            {
                var selectStatement = "SELECT CustomerID, Name, Address, City, State, ZipCode " +
                                            "FROM Customers " +
                                            "WHERE CustomerID = @CustomerID";

                var selectCommand = new SqlCommand(selectStatement, connection);

                selectCommand.Parameters.AddWithValue("@CustomerID", customerID);

                try
                {
                    connection.Open();
                    using (var customerReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                    {
                        if (customerReader.Read())
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

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static int AddCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(Settings.Default.MMABooksConnectionString))
            {
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
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(Settings.Default.MMABooksConnectionString))
            {
                var updateStatement = "UPDATE Customers " +
                                      "SET Name = @Name, Address = @Address, City = @City, State = @State, ZipCode = @ZipCode " +
                                      "WHERE CustomerID = @CustomerID";

                var updateCommand = new SqlCommand(updateStatement, connection);

                updateCommand.Parameters.AddWithValue("@Name", customer.Name);
                updateCommand.Parameters.AddWithValue("@Address", customer.Address);
                updateCommand.Parameters.AddWithValue("@City", customer.City);
                updateCommand.Parameters.AddWithValue("@State", customer.State);
                updateCommand.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
                updateCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

                try
                {
                    connection.Open();

                    updateCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public static bool DeleteCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(Settings.Default.MMABooksConnectionString))
            {
                var deleteStatement =   "DELETE FROM Customers " +
                                        "WHERE CustomerID = @CustomerID AND " +
                                        "Name = @Name AND " +
                                        "Address = @Address AND " +
                                        "City = @City AND " +
                                        "State = @State AND " + 
                                        "ZipCode = @ZipCode";

                var deleteCommand = new SqlCommand(deleteStatement, connection);

                deleteCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                deleteCommand.Parameters.AddWithValue("@Name", customer.Name);
                deleteCommand.Parameters.AddWithValue("@Address", customer.Address);
                deleteCommand.Parameters.AddWithValue("@City", customer.City);
                deleteCommand.Parameters.AddWithValue("@State", customer.State);
                deleteCommand.Parameters.AddWithValue("@ZipCode", customer.ZipCode);


                try
                {
                    connection.Open();

                    int count = deleteCommand.ExecuteNonQuery();
                    if(count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
}
