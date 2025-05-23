namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Transcation
{
    public partial class TranscationController
    {
        public class TranscationRequestModel()
        {
            public string FromMobileNo { get; set; }    

            public string ToMobileNo { get; set; }  

            public decimal Amount { get; set; }  
        }

       
    }
}
