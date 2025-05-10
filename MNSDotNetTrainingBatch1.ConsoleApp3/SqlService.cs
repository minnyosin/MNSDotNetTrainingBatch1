using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace MNSDotNetTrainingBatch1.ConsoleApp3
{
    internal class SqlService
    {
        SqlConnectionStringBuilder _sqlconnetConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };

        public List<T> Query<T>(string query, object? parameters = null!)
        {
            using IDbConnection connection = new SqlConnection(_sqlconnetConnectionStringBuilder.ConnectionString);
            connection.Open();
            var lst = connection.Query<T>(query, parameters).ToList();
            return lst;
        }

        public int Execute(string query, object? parameters = null!)
        {
            using IDbConnection connection = new SqlConnection(_sqlconnetConnectionStringBuilder.ConnectionString);
            connection.Open();
            int result = connection.Execute(query, parameters);
            return result;
        }
    }
}
