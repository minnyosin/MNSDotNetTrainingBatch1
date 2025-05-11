using System;
using System.Collections.Generic;

namespace ClassLibrary1MNSDotNetTrainingBatch1.Database.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
