using MNSDotNetTrainingBatch1.TestEFCore;

Console.WriteLine("Hello World!");

AppDbContext appDbContext = new AppDbContext();

//var lst = appDbContext.ProductCategory.ToList();

//foreach (var item in lst)
//{
//    Console.WriteLine(item.Code);
//    Console.WriteLine(item.Name);
//}

//var lst = appDbContext.ProductCategory.FirstOrDefault(x => x.Code == "C001");

//if (lst is null)
//{
//    Console.WriteLine("Item not found");
//    return;
//}

//Console.WriteLine(lst.Code);
//Console.WriteLine(lst.Name);

//appDbContext.ProductCategory.Add(new ProductCategory()
//{
//    Code = "C005",
//    Name = "Stationary"
//});
//int result = appDbContext.SaveChanges();

//string message = result > 0 ? "Insert Successful" : "Insert Failed";
//Console.WriteLine(message);

//var lst = appDbContext.ProductCategory.FirstOrDefault(x => x.Code == "C003");

//if (lst is null)
//{
//    Console.WriteLine("Item not found");
//    return;
//}
//lst.Name = "DairyProduct";

//int result = appDbContext.SaveChanges();

//string message = result > 0 ? "Update Successful" : "Update Failed";
//Console.WriteLine(message);

var lst = appDbContext.ProductCategory.FirstOrDefault(x => x.Code == "C005");
if (lst is null)
{
    Console.WriteLine("Item not found");
    return;
}

appDbContext.ProductCategory.Remove(lst);
int result = appDbContext.SaveChanges();

string message = result > 0 ? "Delete Successful" : "Delete Failed";
Console.WriteLine(message);

Console.ReadLine();