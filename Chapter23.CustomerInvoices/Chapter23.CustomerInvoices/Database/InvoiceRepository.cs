using Chapter23.CustomerInvoices.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Chapter23.CustomerInvoices.Database
{
    public static class InvoiceRepository
    {
        public static IEnumerable<Invoice> GetInvoices()
        {
            var invoices = new List<Invoice>();

            using (var connection = new SqlConnection(Properties.Settings.Default.MMABooksConnectionString))
            {
                var selectText =    "SELECT InvoiceID, CustomerID, InvoiceDate, InvoiceTotal " +
                                    "FROM Invoices " +
                                    "ORDER BY CustomerID";

                var selectCommand = new SqlCommand(selectText, connection);

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Invoice newInvoice = new Invoice
                            {
                                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                                InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                                InvoiceTotal = Convert.ToSingle(reader["InvoiceTotal"])
                            };

                            invoices.Add(newInvoice);
                        }

                        reader.Close();
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

            return invoices;
        }
    }
}
