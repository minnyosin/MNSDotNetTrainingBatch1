using System.Data;
using System.Globalization;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MNSDotNetTrainingBatch1.TestDapper;

Console.WriteLine("Hello, World!");

SqlService sqlservice = new SqlService();



//var lst = connection.Query<ProductCategory>("select * from Tbl_ProductCategory").ToList();

//foreach (var item in lst)
//{
//    Console.WriteLine(item.Code);
//    Console.WriteLine(item.Name);
//}

//Console.Write("Enter ProductCode: ");
//string code = Console.ReadLine()!;


//var lst = connection.Query<ProductCategory>("select * from Tbl_ProductCategory where Code = @Code", new
//{
//    Code = code

//}).ToList();

//foreach (var item in lst)
//{
//    Console.WriteLine(item.Code);
//    Console.WriteLine(item.Name);
//}

int result = sqlservice.Execute(@"INSERT INTO [dbo].[Tbl_ProductCategory]
           ([Code]
           ,[Name])
     VALUES
           (@Code
           ,@Name)", new
{
    Code = "C004",
    Name = "Electronic"
});

//string message = result > 0 ? "Insert Successful!" : "Insert Failed!";
//Console.WriteLine(message);


//int result = connection.Execute(@"UPDATE [dbo].[Tbl_ProductCategory]
//   SET [Name] = @Name
// WHERE Code = @Code", new
//{
//    Code = "C003",
//    Name = "Dairy"
//});

//string message = result > 0 ? "Update Successful!" : "Update Failed!";
//Console.WriteLine(message);

//int result = sqlservice.Execute("Delete from Tbl_ProductCategory where Code = @code", new
//{
//    Code = "C004"
//});
//string message = result > 0 ? "Update Successful!" : "Update Failed!";
//Console.WriteLine(message);

Console.ReadLine();

public class ProductCategory
{
    public string Code { get; set; }
    public string Name { get; set; }
}

//Read => readall / readbyid

//Dapper => Query(read) / execute(others)

