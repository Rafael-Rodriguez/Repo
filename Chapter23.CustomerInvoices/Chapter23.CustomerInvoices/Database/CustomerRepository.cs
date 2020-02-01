using Chapter23.CustomerInvoices.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Chapter23.CustomerInvoices.Database
{
    public static class CustomerRepository
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(Properties.Settings.Default.MMABooksConnectionString))
            {
                var selectText =    "SELECT CustomerID, Name " +
                                    "FROM Customers " +
                                    "ORDER BY Name";

                var selectCommand = new SqlCommand(selectText, connection);

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Customer newCustomer = new Customer
                            {
                                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                Name = reader["Name"].ToString()
                            };

                            customers.Add(newCustomer);
                        }

                        reader.Close();
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

            return customers;
        }
    }
}
