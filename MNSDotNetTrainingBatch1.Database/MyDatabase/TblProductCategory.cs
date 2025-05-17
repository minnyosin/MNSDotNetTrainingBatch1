using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.Database.MyDatabase;

public partial class TblProductCategory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
