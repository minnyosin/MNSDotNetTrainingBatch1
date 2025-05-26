using System;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.TestEFCore.DbFirst.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
