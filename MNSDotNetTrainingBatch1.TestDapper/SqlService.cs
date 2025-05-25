using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace MNSDotNetTrainingBatch1.TestDapper
{
    internal class SqlService
    {
        SqlConnectionStringBuilder sqlConnectionstringbuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };

        public List<T> Query<T>(string query, object? parameter = null)
        {
            using IDbConnection connection = new SqlConnection(sqlConnectionstringbuilder.ConnectionString);
            connection.Open();
            var lst = connection.Query<T>(query, parameter).ToList();
            return lst;
        }

        public int Execute(string query, object? parameter = null)
        {
            using IDbConnection connection = new SqlConnection(sqlConnectionstringbuilder.ConnectionString);
            connection.Open();
            int result = connection.Execute(query, parameter);
            return result;
        }
    }
}
