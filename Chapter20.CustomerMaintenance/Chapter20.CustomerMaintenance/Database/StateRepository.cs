using Chapter20.CustomerMaintenance.Models;
using Chapter20.CustomerMaintenance.Properties;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Chapter20.CustomerMaintenance.Database
{
    public class StateRepository
    {
        public static List<State> GetStates()
        {
            var states = new List<State>();

            var connection = new SqlConnection(Settings.Default.MMABooksConnectionString);
            var selectStatement =   "SELECT StateCode, StateName " +
                                    "FROM States " +
                                    "ORDER BY StateName";
            var selectCommand = new SqlCommand(selectStatement, connection);

            try
            {
                connection.Open();

                var reader = selectCommand.ExecuteReader();
                while(reader.Read())
                {
                    var s = new State
                    {
                        StateCode = reader["StateCode"].ToString(),
                        StateName = reader["StateName"].ToString()
                    };

                    states.Add(s);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return states;
        }
    }
}
