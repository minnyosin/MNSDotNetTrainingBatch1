using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.Assigned.DreamDictionary.Database.Models;

public partial class TblBlogDetail
{
    public int BlogDetailId { get; set; }

    public int BlogId { get; set; }

    public string BlogContent { get; set; } = null!;
}
