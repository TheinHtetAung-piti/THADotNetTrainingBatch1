using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Assi.Database.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
