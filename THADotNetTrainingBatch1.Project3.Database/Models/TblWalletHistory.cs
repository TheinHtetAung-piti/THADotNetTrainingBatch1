using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Project3.Database.Models;

public partial class TblWalletHistory
{
    public int WalletHistroyId { get; set; }

    public string MobileNo { get; set; } = null!;

    public string TranscationType { get; set; } = null!;

    public decimal? Amount { get; set; }
}
