using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THADotNetTrainingBatch1.Project3.Database.Models;
using THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Deposit;
using static THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet.RegisterWalletController;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Withdraw
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly decimal _minimunAmount;
        private readonly IConfiguration _configuration;

        public WithdrawController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _minimunAmount = Convert.ToDecimal(_configuration.GetSection("MinimunAmount").Value);
        }

        [HttpPost]
        public IActionResult Execute(WithdrawRequestModel requestModel)
        {

            WithdrawResponseModel model;
            #region Vadilation amount and mobileNo
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new WithdrawResponseModel
                {
                    Message = "Mobile No is required"
                };
                goto Result;
            }

            if (requestModel.Amount <= 0)
            {
                model = new WithdrawResponseModel
                {
                    Message = "Amount must be greater than zero!"
                };
                goto Result;
            }
            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (itemWallet == null)
            {
                model = new WithdrawResponseModel
                {
                    Message = "Wallet User Doesn't Exist"
                };
                goto Result;
            }

            #endregion
            decimal oldBalance = itemWallet.Balance;
            if(oldBalance - _minimunAmount < requestModel.Amount)
            {
                model = new WithdrawResponseModel
                {
                    Message = $"Insufficient Amount. Minimum amount must be {_minimunAmount.ToString("N2")}"
                };
                goto Result;
            }
            decimal newBalance = itemWallet.Balance - requestModel.Amount;
            itemWallet.Balance = newBalance;
            _appDbContext.SaveChanges();

            _appDbContext.TblWalletHistories.Add(new TblWalletHistory
            {
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                TranscationType = "Withdraw"
            });
            _appDbContext.SaveChanges();

            model = new WithdrawResponseModel
            {
                IsSuccess = true,
                Message = $"Depoist amount {requestModel.Amount}",
                OldBalance = oldBalance,
                NewBalance = newBalance,

            };

        Result:
            return Ok(model);
        }

        public class WithdrawRequestModel()
        {
            public string MobileNo { get; set; }    
            public decimal Amount { get; set; } 

        }

        public class WithdrawResponseModel : ResponseModel
        {
            public decimal OldBalance { get; set; } 

            public decimal NewBalance { get; set; } 
        }
    }

   
}

