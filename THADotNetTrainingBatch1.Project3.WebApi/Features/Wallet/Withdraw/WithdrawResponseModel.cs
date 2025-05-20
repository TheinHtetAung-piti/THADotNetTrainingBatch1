using static THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet.RegisterWalletController;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Withdraw
{
    public partial class WithdrawController
    {
        public class WithdrawResponseModel : ResponseModel
        {
            public decimal OldBalance { get; set; } 

            public decimal NewBalance { get; set; } 
        }
    }

   
}

