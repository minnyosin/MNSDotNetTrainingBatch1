using Microsoft.EntityFrameworkCore;
using MNSDotNetTrainingBatch1.TestEFCore.DbFirst.Models;

Console.WriteLine("Hello, World!");

AppDbContext appDbContext = new AppDbContext();

var lst = appDbContext.TblProductCategories.ToList();

foreach(var item in lst)
{
    Console.WriteLine(item.Code);
    Console.WriteLine(item.Name);
}

Console.ReadLine();