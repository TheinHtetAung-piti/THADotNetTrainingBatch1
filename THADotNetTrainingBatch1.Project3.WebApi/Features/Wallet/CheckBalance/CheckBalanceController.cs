using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THADotNetTrainingBatch1.Project3.Database.Models;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.CheckBalance
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CheckBalanceController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CheckBalanceController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Get(BalanceRequestModel requestModel)
        {
            BalanceResponseModel model;

            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new BalanceResponseModel
                {
                    Message = "Need to enter the mobile No "
                };
                goto Result;
            }

            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
            if (itemWallet == null)
            {
                model = new BalanceResponseModel
                {
                    Message = "Waller user not found"
                };
                goto Result;
            }

            decimal balance = itemWallet.Balance;

            model = new BalanceResponseModel
            {
                IsSuccess = true,
                MobileNo = requestModel.MobileNo,
                Balance = balance,
                Message = $"Total Balance is {balance}"
            };
        Result:
            return Ok(model);
        }
    }
}
