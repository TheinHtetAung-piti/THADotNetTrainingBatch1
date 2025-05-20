using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Project3.Database.Models;

public partial class TblTranscation
{
    public string TranscationId { get; set; } = null!;

    public string TranscationNo { get; set; } = null!;

    public string FromMobileNo { get; set; } = null!;

    public string ToMobileNo { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime TransctationDate { get; set; }
}
