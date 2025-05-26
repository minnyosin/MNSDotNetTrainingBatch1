using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.TestEFCore.DbFirst.Models;

public partial class TblProductCategory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
