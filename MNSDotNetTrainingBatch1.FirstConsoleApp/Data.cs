using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSDotNetTrainingBatch1.FirstConsoleApp
{
    internal class Data
    {
        public static int ProductId { get; set; } = 2;

        public static List<Product> Products = new List<Product>()
        {
            new Product(1, "P001", "Apple", 3000, 10, "Fruit"),
            new Product(2, "P002", "Orange", 3000, 10, "Fruit")
        };

    }
}
