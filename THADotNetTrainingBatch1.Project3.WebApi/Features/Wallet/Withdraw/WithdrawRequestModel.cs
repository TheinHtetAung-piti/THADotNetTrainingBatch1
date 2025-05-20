namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Withdraw
{
    public partial class WithdrawController
    {
        public class WithdrawRequestModel()
        {
            public string MobileNo { get; set; }    
            public decimal Amount { get; set; } 

        }
    }

   
}

