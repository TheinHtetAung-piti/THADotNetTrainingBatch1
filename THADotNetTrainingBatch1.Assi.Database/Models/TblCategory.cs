using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Assi.Database.Models;

public partial class TblCategory
{
    public int Id { get; set; }

    public string? CategoryCode { get; set; }

    public string Category { get; set; } = null!;
}
