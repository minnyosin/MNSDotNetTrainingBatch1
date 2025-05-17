using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.Database.MyDatabase;

public partial class TblUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
