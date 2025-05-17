using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.Database.MyDatabase;

public partial class TblBlogHeader
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;
}
