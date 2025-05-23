using THADotNetTrainingBatch1.Project3.Database.Models;
using static THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet.RegisterWalletController;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.CheckBalance
{
    public partial class CheckBalanceController
    {
        public class BalanceResponseModel() : ResponseModel
        {
            public string MobileNo { get; set; }

            public decimal Balance { get; set; }

            public List<TranscationHistoryResoponseModel> TranscationHistoryList { get; set; }
        }

        public class TranscationHistoryResoponseModel : TblTranscation
        {
             
        }
    }

   
}
