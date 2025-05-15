using System.Data;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;
using MNSDotNetTrainingBatch1.Shared;
using Newtonsoft.Json;

using MNSDotNetTrainingBatch1.FirstConsoleApp;

StartofSystem:
Console.WriteLine("Inventory Management System");
Console.WriteLine("-----------------------------");
InventoryService inventoryService = new InventoryService();


Console.WriteLine("1. Create a new Product");
Console.WriteLine("2. View Product");
Console.WriteLine("3. Update the product");
Console.WriteLine("4. Delete the product");
Console.WriteLine("5. Exit");
Console.Write("Choose any options: ");


string chooseOptions = Console.ReadLine()!;
bool IsInt = int.TryParse(chooseOptions, out int options);
if (!IsInt)
{
    Console.WriteLine("Invalid Input!!\n");
    goto StartofSystem;
}
switch (options)
{
    case 1:
        Console.WriteLine("\nCreating a product...\n");
        inventoryService.CreateProduct();
        goto StartofSystem;

    case 2:
        Console.WriteLine("\nHere is the product list of your inventory: \n");
        inventoryService.ViewProduct();
        goto StartofSystem;

    case 3:
        Console.WriteLine("\nUpdating the product... \n");
        inventoryService.UpdateProduct();
        goto StartofSystem;

    case 4:
        Console.WriteLine("\nDeleting the product... \n");
        inventoryService.DeleteProduct();
        goto StartofSystem;

    case 5:
        Console.WriteLine("\nExisting the Program...");
        goto EndOfSystem;

    default:
        Console.WriteLine("\nInvalid option entered!! Please choose again.\n");
        goto StartofSystem;
}

EndOfSystem:
Console.ReadKey();
