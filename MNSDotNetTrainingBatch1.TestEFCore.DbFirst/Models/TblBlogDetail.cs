using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.TestEFCore.DbFirst.Models;

public partial class TblBlogDetail
{
    public int BlogDetailId { get; set; }

    public int BlogId { get; set; }

    public string BlogContent { get; set; } = null!;
}
