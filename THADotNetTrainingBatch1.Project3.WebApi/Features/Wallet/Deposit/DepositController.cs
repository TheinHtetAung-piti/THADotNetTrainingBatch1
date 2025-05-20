using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THADotNetTrainingBatch1.Project3.Database.Models;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.Deposit
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public DepositController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(DepositRequestModel requestModel)
        {
        
        DepositResponseModel model;
            #region Vadilation amount and mobileNo
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new DepositResponseModel
                {
                    Message = "Mobile No is required"
                };
                goto Result; 
            }

            if (requestModel.Amount <= 0 )
            {
                model = new DepositResponseModel
                {
                    Message = "Amount must be greater than zero!"
                };
                goto Result;
            }
            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
                if (itemWallet == null)
            {
                model = new DepositResponseModel
                {
                    Message = "Wallet User Doesn't Exist"
                };
                goto Result;
            }

            #endregion
            decimal oldBalance = itemWallet.Balance;
            decimal newBalance = itemWallet.Balance + requestModel.Amount;
            itemWallet.Balance = newBalance;
            _appDbContext.SaveChanges();

            model = new DepositResponseModel
            {
                IsSuccess = true,
                Message = $"Depoist amount {requestModel.Amount}",
                OldBalance = oldBalance,
                NewBalance = newBalance,

            };

        Result:
            return Ok(model);
        }
    }
}
