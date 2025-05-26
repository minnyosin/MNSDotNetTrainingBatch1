using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.TestEFCore.DbFirst.Models;

public partial class TblInventoryService
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string Category { get; set; } = null!;
}
