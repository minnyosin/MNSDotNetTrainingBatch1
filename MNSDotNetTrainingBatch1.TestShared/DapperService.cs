using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace MNSDotNetTrainingBatch1.TestShared
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;
        public DapperService(SqlConnectionStringBuilder connectionStringBuilder)
        {
            _connectionStringBuilder = connectionStringBuilder;
        }
        public List<T> Query<T>(string query, object? parameters = null!)
        {
            using IDbConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();
            var lst = connection.Query<T>(query, parameters).ToList();
            return lst;
        }

        public int Execute(string query, object? parameters = null!)
        {
            using IDbConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
            connection.Open();
            int result = connection.Execute(query, parameters);
            return result;
        }

    }
}
