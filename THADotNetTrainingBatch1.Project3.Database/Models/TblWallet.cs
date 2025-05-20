using System;
using System.Collections.Generic;

namespace THADotNetTrainingBatch1.Project3.Database.Models;

public partial class TblWallet
{
    public int WalletId { get; set; }

    public string WalletUserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public decimal Balance { get; set; }
}
