using static THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet.RegisterWalletController;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.CheckBalance
{
    public partial class CheckBalanceController
    {
        public class BalanceResponseModel() : ResponseModel
        {
            public string MobileNo { get; set; }

            public decimal Balance { get; set; }
        }
    }
}
