using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Data;

namespace MNSDotNetTrainingBatch1.Shared
{
    public class DapperService : IDbV2Service
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public DapperService(IConfiguration configuration)
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("Dbconnection"));
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
