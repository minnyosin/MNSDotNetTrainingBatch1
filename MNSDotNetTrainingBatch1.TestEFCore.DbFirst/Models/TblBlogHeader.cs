using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.TestEFCore.DbFirst.Models;

public partial class TblBlogHeader
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;
}
