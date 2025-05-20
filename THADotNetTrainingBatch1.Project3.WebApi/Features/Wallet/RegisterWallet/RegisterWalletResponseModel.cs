namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet
{
    public partial class RegisterWalletController
    {
        public class RegisterWalletResponseModel() : ResponseModel
        {
            public int WalletId { get; set; }
            public string WalleetUserName { get; set; }
            public string FullName { get; set; }    
            public string MobileNo { get; set; }    
        
        }

    }
}
