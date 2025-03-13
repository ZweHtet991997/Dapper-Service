using Dapper_Service.Config;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper_Service.Services
{
    public class DbConnectionService
    {
        private readonly string connectionString = DatabaseConfig.GetConnectionString();
        private SqlConnection connection;

        public SqlConnection OpenConnection()
        {
            if (connection is null) { connection = new SqlConnection(connectionString); }
            if (connection.State != ConnectionState.Open) { connection.Open(); }

            return connection;
        }

        public void CloseConnection()
        {
            if (connection is not null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public void Dispose()
        {
            if (connection is not null)
            {
                connection.Dispose();
                connection = null;
            }
        }
    }
}