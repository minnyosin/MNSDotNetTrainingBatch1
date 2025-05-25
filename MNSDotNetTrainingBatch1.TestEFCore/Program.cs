using MNSDotNetTrainingBatch1.TestEFCore;

Console.WriteLine("Hello World!");

AppDbContext appDbContext = new AppDbContext();

var lst = appDbContext.ProductCategory.ToList();

foreach(var item in lst)
{
    Console.WriteLine(item.Code);
    Console.WriteLine(item.Name);
}

Console.ReadLine();