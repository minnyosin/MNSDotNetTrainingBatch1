using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MNSDotNetTrainingBatch1.Shared
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public DapperService(SqlConnectionStringBuilder sqlconnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlconnectionStringBuilder;
        }

        public List<T> Query<T>(string query, object? parameters = null!)
        {
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            var lst = connection.Query<T>(query, parameters).ToList();
            return lst;
        }

        public int Execute(string query, object? parameters = null!)
        {
            using IDbConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            int result = connection.Execute(query, parameters);
            return result;
        }
    }
}
