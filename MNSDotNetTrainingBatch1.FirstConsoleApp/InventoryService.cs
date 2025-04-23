using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSDotNetTrainingBatch1.FirstConsoleApp
{
    internal class InventoryService
    {
        public void CreateProduct()
        {
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

            Data.ProductId++;
            string productCode = "P" + Data.ProductId.ToString().PadLeft(3, '0');
            Product product = new Product(Data.ProductId, productCode, newProductName, price, quantity, "Fruit");
            Data.Products.Add(product);

            Console.WriteLine("\nProduct Inserted Successfully!\n");
        }

        public void ViewProduct()
        {
            foreach (var product in Data.Products)
            {
                Console.WriteLine($"Id: {product.Id}, Code: {product.Code}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Catagory: Fruit");
            }
            Console.WriteLine('\n');
        }

        public void UpdateProduct()
        {
        UpdatingProduct:
            Console.Write("Enter the Product code you want to update: ");
            string updateProduct = Console.ReadLine()!;

            var originalProduct = Data.Products.FirstOrDefault(a => a.Code == updateProduct);
            if (originalProduct == null)
            {
                Console.WriteLine("\nSorry...Product cannot be found.\n");
                goto UpdatingProduct;
            }
            Console.WriteLine("\nThe Product found!\n");
            Console.WriteLine($"Code: {originalProduct.Code}, Name: {originalProduct.Name}, Price: {originalProduct.Price}, Quantity: {originalProduct.Quantity}");
            Console.WriteLine('\n');

            var newProduct = originalProduct.Clone();

        RemovingQuantity:
            Console.Write("How much do you want to remove from the existing quantity?: ");
            string quantity = Console.ReadLine()!;
            bool IsInt = int.TryParse(quantity, out int removeQuantity);
            if (!IsInt)
            {
                Console.WriteLine("\nInvalid input\n");
                goto RemovingQuantity;
            }
            if (removeQuantity > newProduct.Quantity)
            {
                Console.WriteLine("\nNot enough quantity in the inventory!\n");
                goto RemovingQuantity;
            }
            newProduct.Quantity -= removeQuantity;
            Console.WriteLine("\nThe Quantity removed successfully!\n");
        }

        public void DeleteProduct()
        {
        DeletingProduct:
            Console.Write("Enter the product code you want to delete: ");
            string deleteProduct = Console.ReadLine()!;
            var product = Data.Products.FirstOrDefault(a => a.Code == deleteProduct);
            if (product == null)
            {
                Console.WriteLine("\nSorry...Product cannot be found.\n");
                goto DeletingProduct;
            }
            Console.WriteLine("\nThe Product found!\n");
            Console.WriteLine($"Id: {product.Id}, Code: {product.Code}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Catagory: Fruit");
            Console.WriteLine("\n");

        AreYouSure:
            Console.Write("Are you sure you want to delete the product?(y for yes, n for no): ");
            string IsSure = Console.ReadLine()!;
            if (IsSure == "y")
            {
                Data.Products.Remove(product);
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
        }
    }
}
