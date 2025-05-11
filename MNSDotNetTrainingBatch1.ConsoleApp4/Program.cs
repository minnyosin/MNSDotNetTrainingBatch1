using System.Runtime.CompilerServices;
using MNSDotNetTrainingBatch1.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

AdoDotNetService adoDotNetService = new AdoDotNetService(new SqlConnectionStringBuilder
{
    DataSource = ".",
    InitialCatalog = "DotNetTrainingBatch1",
    UserID = "sa",
    Password = "sa@123",
    TrustServerCertificate = true
});

string query = "select * from Tbl_Product";
var lst = adoDotNetService.QueryV2<Product>(query);

foreach (var item in lst)
{
    Console.WriteLine("Id: " + item.ProductId);
    Console.WriteLine("Name: " + item.ProductCode);
    Console.WriteLine("Price: " + item.Price);
    Console.WriteLine("Quantity: " + item.Quantity);
    Console.WriteLine("Created Date: " + item.CreatedDateTime);
    Console.WriteLine("Created By: " + item.CreatedBy);
    Console.WriteLine("------------------------");
}


public class Product
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public int CreatedBy { get; set; }
    //public DateTime ModifiedDate { get; set; }
    //public int ModifiedBy { get; set; }
}