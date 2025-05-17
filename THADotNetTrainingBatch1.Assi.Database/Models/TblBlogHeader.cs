using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Assi.Database.Models;

public partial class TblBlogHeader
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;
}
