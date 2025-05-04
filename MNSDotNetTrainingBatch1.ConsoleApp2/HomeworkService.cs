using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1MNSDotNetTrainingBatch1.ConsoleApp2
{
    internal class HomeworkService
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true

        };
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = "select * from Tbl_Homework";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["No"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["GitHubUserName"]);
                Console.WriteLine(dr["GitHubRepoLink"]);
                Console.WriteLine("-------------------");
            }
        }
        public void Detail()
        {
        beforeDetail:
            Console.Write("Enter No: ");
            string input = Console.ReadLine()!;
            bool IsInt = int.TryParse(input, out int no);

            if (!IsInt)
            {
                Console.WriteLine("Invalid Input!");
                goto beforeDetail;
            }

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = $"select * from Tbl_Homework where No = @No";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@No", no);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found!");
                goto beforeDetail;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine(dr["No"]);
            Console.WriteLine(dr["Name"]);
            Console.WriteLine(dr["GitHubUserName"]);
            Console.WriteLine(dr["GitHubRepoLink"]);
            Console.WriteLine("-------------------");
        }

        public void Create()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter GitHubUserName: ");
            string githubUserName = Console.ReadLine()!;

            Console.Write("Enter GitHubRepoLink: ");
            string githubRepoLink = Console.ReadLine()!;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Homework]
           ([Name]
           ,[GitHubUserName]
           ,[GitHubRepoLink])
     VALUES
           (@Name,
           @GitHubUserName,
           @GitHubRepoLink)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
            cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);

            int result = cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Update()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();

        beforeUpdate:
            Console.Write("Enter No: ");
            string input = Console.ReadLine()!;
            bool IsInt = int.TryParse(input, out int no);

            if (!IsInt)
            {
                Console.WriteLine("Invalid Input!");
                goto beforeUpdate;
            }

            string query = $"select * from Tbl_Homework where No = @No";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@No", no);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                Console.WriteLine("Product Found!");
            }
            else
            {
                Console.WriteLine("Product Not Found!");
                goto beforeUpdate;
            }


            Console.Write("Enter New Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter New GitHubUserName: ");
            string githubUserName = Console.ReadLine()!;

            Console.Write("Enter New GitHubRepoLink: ");
            string githubRepoLink = Console.ReadLine()!;

            string query1 = @"UPDATE [dbo].[Tbl_Homework]
          SET [Name] = @Name
             ,[GitHubUserName] = @GitHubUserName
             ,[GitHubRepoLink] = @GitHubRepoLink
        WHERE No = @No;";

            SqlCommand cmd1 = new SqlCommand(query1, connection);
            cmd1.Parameters.AddWithValue("@No", no);
            cmd1.Parameters.AddWithValue("@Name", name);
            cmd1.Parameters.AddWithValue("@GitHubUserName", githubUserName);
            cmd1.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);
            int result = cmd1.ExecuteNonQuery();
            connection.Close();

            string check = result == 1 ? "Update Successful!" : "Update Failed";
            Console.WriteLine(check);

            
        }
        public void Delete()
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

        beforeDelete:
            Console.Write("Enter No: ");
            string input = Console.ReadLine()!;
            bool IsInt = int.TryParse(input, out int no);

            if (!IsInt)
            {
                Console.WriteLine("Invalid Input!");
                goto beforeDelete;
            }

            string query = $"select * from Tbl_Homework where No = @No";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@No", no);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                Console.WriteLine("Product Found!");
            }
            else
            {
                Console.WriteLine("Product Not Found!");
                goto beforeDelete;
            }

            string query1 = $"delete from Tbl_Homework where No = @No";

            SqlCommand cmd1 = new SqlCommand(query1, connection);
            cmd1.Parameters.AddWithValue("@No", no);
            int result = cmd1.ExecuteNonQuery();

            string check = result == 1 ? "Delete Successful!" : "Delete Failed!";
            Console.WriteLine(check);

            connection.Close();
        }
    }
}

