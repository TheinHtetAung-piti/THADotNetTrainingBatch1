﻿namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet
{
    public partial class RegisterWalletController
    {
        public class RegisterWalletRequestModel()
        {
            public string? WalletUserName { get; set; }
            public string? FullName { get; set; }

            public string? MobileNo { get; set; }
        }

    }
}
