using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.Database.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
