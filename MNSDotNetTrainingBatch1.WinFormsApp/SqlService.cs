using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace MNSDotNetTrainingBatch1.WinFormsApp
{
    public class SqlService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
        DataSource = ".",
        InitialCatalog = "DotNetTrainingBatch1",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true

    };

        public DataTable Query(string query, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters.ToArray());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }


        public int Execute(string query, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters.ToArray());
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result;
        } 
        
    }
}
