// See https://aka.ms/new-console-template for more information
using ClassLibrary1MNSDotNetTrainingBatch1.Database.Models;
using Microsoft.EntityFrameworkCore;
using MNSDotNetTrainingBatch1.Database.NorthwindModels;

Console.WriteLine("Hello, World!");


//AppDbContext db = new AppDbContext();
//db.TblProductCategories.Add(new TblProductCategory
//{
//    Code = "C003",
//    Name = "Dairy Product"
//});

//db.TblProductCategories.FirstOrDefault(x => x.Id == 3);

//int result = db.SaveChanges();

NorthwindAppDbContext db2 = new NorthwindAppDbContext();
var lst = db2.Categories.Include(x => x.Products).ToList();
//db2.SaveChanges();

Console.ReadLine();


//dotnet ef dbcontext scaffold "Server=.;Database=Northwind;User Id=sa;Password=sa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o NorthwindModels -c NorthwindAppDbContext -f
