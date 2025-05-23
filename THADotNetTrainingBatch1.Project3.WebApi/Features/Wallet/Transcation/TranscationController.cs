using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using THADotNetTrainingBatch1.Project3.Database.Models;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Transcation
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class TranscationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private decimal _minAmount;
        private IConfiguration _configuration;



        public TranscationController(AppDbContext appDbContext,IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _minAmount = Convert.ToDecimal(_configuration.GetSection("MinimunAmount").Value);
        }

        [HttpPost]
        public IActionResult Execute(TranscationRequestModel requestModel)
        {
            TranscationResponseModel model;
            #region Vadilation
            if (string.IsNullOrEmpty(requestModel.FromMobileNo))
            {
                model = new TranscationResponseModel
                {
                    Message = "From Mobile is need!"
                };
                goto Result;
            }

            if(string.IsNullOrEmpty(requestModel.ToMobileNo))
            {
                model = new TranscationResponseModel
                {
                    Message = "To MobileNo is required",
                };
                goto Result;
            }

            if(requestModel.Amount <= 0)
            {
                model = new TranscationResponseModel
                {
                    Message = "Amount must be greater than 0"
                };
                goto Result;
            }
            #endregion
            var toItem = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.ToMobileNo);
            if (toItem is null)
            {
                model = new TranscationResponseModel
                {
                    Message = "To Mobile no doesn't exist",
                };
                goto Result;
            }


            var fromItem = _appDbContext.TblWallets.FirstOrDefault(x=> x.MobileNo == requestModel.FromMobileNo);
            if(fromItem is null)
            {
                model = new TranscationResponseModel
                {
                    Message = "From mobile no doesn't exist",
                };
                goto Result;
            }

            if(requestModel.Amount > fromItem.Balance - _minAmount)
            {
                model = new TranscationResponseModel
                {
                    Message = "Not enough Balance"
                };
                goto Result;
            }

            fromItem.Balance -= requestModel.Amount;
            toItem.Balance += requestModel.Amount;

            _appDbContext.TblTranscations.Add(new TblTranscation
            {
                ToMobileNo = requestModel.ToMobileNo,
                FromMobileNo = requestModel.FromMobileNo,
                Amount = requestModel.Amount,
                TransctationDate = DateTime.Now,
                TranscationId = Guid.NewGuid().ToString(),
                //TranscationNo = 
            });
            model = new TranscationResponseModel
            {
                IsSuccess = true,
                Message = "Transcation Success"
            };
        Result:
            return Ok(model);
        }

       
    }
}
