using static THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet.RegisterWalletController;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Deposit
{
    public class DepositResponseModel() : ResponseModel
    {
        public decimal NewBalance { get; set; }
        public decimal OldBalance { get; set; } 
    }
}
