using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MNSDotNetTrainingBatch1.FirstConsoleApp
{
    internal class InventoryService
    {

        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };

        public void CreateProduct()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_InventoryServices]
           ([Code]
           ,[Name]
           ,[Price]
           ,[Quantity]
           ,[Category])
     VALUES
           (@Code
           ,@Name
           ,@Price
           ,@Quantity
           ,@Category)";
            SqlCommand cmd = new SqlCommand(query, connection);
            Console.Write("Input Product Name: ");
            string newProductName = Console.ReadLine()!;

        InsertPriceAgain:
            Console.Write("Input Product Prce: ");
            string newProductPrice = Console.ReadLine()!;
            bool IsDecimal = decimal.TryParse(newProductPrice, out decimal price);
            if (!IsDecimal)
            {
                Console.WriteLine("Invalid Price!");
                goto InsertPriceAgain;
            }

        InsertQuantityAgain:
            Console.Write("Input Product Quantity: ");
            string newProductQuantity = Console.ReadLine()!;
            bool IsInt = int.TryParse(newProductQuantity, out int quantity);
            if (!IsInt)
            {
                Console.WriteLine("Invalid Quantity!");
                goto InsertQuantityAgain;
            }

            string getMaxIdQuery = "SELECT ISNULL (MAX(Id), 0) + 1 FROM Tbl_InventoryServices"; //codes generated with gpt
            SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, connection);
            int nextId = (int)getMaxIdCmd.ExecuteScalar();
            string productCode = "P" + nextId.ToString().PadLeft(3, '0');

            cmd.Parameters.AddWithValue("@Code", productCode);
            cmd.Parameters.AddWithValue("@Name", newProductName);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Category", "Fruit");
            cmd.ExecuteNonQuery();

            connection.Close();


            Console.WriteLine("\nProduct Inserted Successfully!\n");
        }

        public void ViewProduct()
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = "select * from Tbl_InventoryServices";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id: " + dr["Id"]);
                Console.WriteLine("Code: " + dr["Code"]);
                Console.WriteLine("Name: " + dr["Name"]);
                Console.WriteLine("Price: " + dr["Price"]);
                Console.WriteLine("Quantity: " + dr["Quantity"]);
                Console.WriteLine("Category: " + "Fruit");
                Console.WriteLine("--------------------");
                Console.WriteLine('\n');

            }
            connection.Close();
        }

        public void UpdateProduct()
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

        UpdatingProduct:
            Console.Write("Enter the Product code you want to update: ");
            string updateProduct = Console.ReadLine()!;

            //var originalProduct = Data.Products.FirstOrDefault(a => a.Code == updateProduct);

            string query1 = $"select * from Tbl_InventoryServices where Code = '{updateProduct}'";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sqlDataAdapter1.Fill(dt);

            int checkCode = dt.Rows.Count;

            if (checkCode == 0)
            {
                Console.WriteLine("\nSorry...Product cannot be found.\n");
                goto UpdatingProduct;
            }
            Console.WriteLine("\nThe Product found!\n");

            DataRow dr = dt.Rows[0];

            Console.WriteLine("Id: " + dr["Id"]);
            Console.WriteLine("Code: " + dr["Code"]);
            Console.WriteLine("Name: " + dr["Name"]);
            Console.WriteLine("Price: " + dr["Price"]);
            Console.WriteLine("Quantity: " + dr["Quantity"]);
            Console.WriteLine("Category: " + "Fruit");
            Console.WriteLine("--------------------");
            Console.WriteLine('\n');

        //var newProduct = originalProduct.Clone();

        RemovingQuantity:
            Console.Write("How much do you want to remove from the existing quantity?: ");
            string quantity = Console.ReadLine()!;
            bool IsInt = int.TryParse(quantity, out int removeQuantity);
            if (!IsInt)
            {
                Console.WriteLine("\nInvalid input\n");
                goto RemovingQuantity;
            }
            if (removeQuantity > (int)dr["Quantity"])
            {
                Console.WriteLine("\nNot enough quantity in the inventory!\n");
                goto RemovingQuantity;
            }
            int value = (int)dr["Quantity"];
            value -= removeQuantity;

            string query = $@"UPDATE [dbo].[Tbl_InventoryServices]
   SET [Quantity] = @Quantity
 WHERE [Code] = '{updateProduct}'";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Quantity", value);
            cmd.ExecuteNonQuery();

            Console.WriteLine("\nThe Quantity removed successfully!\n");

            connection.Close();
        }

        public void DeleteProduct()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

        DeletingProduct:
            Console.Write("Enter the product code you want to delete: ");
            string deleteProduct = Console.ReadLine()!;

            string query1 = $"select * from Tbl_InventoryServices where Code = '{deleteProduct}'";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sqlDataAdapter1.Fill(dt);

            int checkCode = dt.Rows.Count;

            //var product = Data.Products.FirstOrDefault(a => a.Code == deleteProduct);
            if (checkCode == 0)
            {
                Console.WriteLine("\nSorry...Product cannot be found.\n");
                goto DeletingProduct;
            }
            Console.WriteLine("\nThe Product found!\n");

            DataRow dr = dt.Rows[0];

            Console.WriteLine("Id: " + dr["Id"]);
            Console.WriteLine("Code: " + dr["Code"]);
            Console.WriteLine("Name: " + dr["Name"]);
            Console.WriteLine("Price: " + dr["Price"]);
            Console.WriteLine("Quantity: " + dr["Quantity"]);
            Console.WriteLine("Category: " + "Fruit");
            Console.WriteLine("--------------------");
            Console.WriteLine('\n');

        AreYouSure:
            Console.Write("Are you sure you want to delete the product?(y for yes, n for no): ");
            string IsSure = Console.ReadLine()!;
            if (IsSure.ToLower() == "y")
            {
                string query = $"delete from Tbl_InventoryServices where Code = '{deleteProduct}'";
                SqlCommand cmd = new SqlCommand (query, connection);
                cmd.Parameters.AddWithValue("@Id", dr["Id"]);
                cmd.Parameters.AddWithValue("@Code", dr["Code"]);
                cmd.Parameters.AddWithValue("@Name", dr["Name"]);
                cmd.Parameters.AddWithValue("@Price", dr["Price"]);
                cmd.Parameters.AddWithValue("@Quantity", dr["Quantity"]);
                cmd.Parameters.AddWithValue("@Category", "Fruit");
                cmd.ExecuteNonQuery();

                Console.WriteLine("\nProduct deleted successfully!\n");
            }
            else if (IsSure == "n")
            {
                Console.WriteLine("\nThe product was not deleted.\n");
                return;
            }
            else
            {
                Console.WriteLine("\nInvalid Input!\n");
                goto AreYouSure;
            }
            connection.Close();

        }
    }
}
