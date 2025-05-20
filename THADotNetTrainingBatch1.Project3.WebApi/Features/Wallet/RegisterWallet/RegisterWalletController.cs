using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THADotNetTrainingBatch1.Project3.Database.Models;

namespace THADotNetTrainingBatch1.Project3.WebApi.Features.Wallet.RegisterWallet
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class RegisterWalletController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public RegisterWalletController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(RegisterWalletRequestModel requestModel)
        {   

            RegisterWalletResponseModel model;
            #region Required Fields
            if (string.IsNullOrEmpty(requestModel.WalletUserName))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet UserName is Required"
                };
                goto Result;
            }

            if(string.IsNullOrEmpty(requestModel.FullName))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Full Name is Required"
                };
                goto Result;
            }

            if(string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "MobileNo is Required"
                };
                goto Result;
            }

            TblWallet item = new TblWallet
            {
                Balance = 0 , 
                FullName = requestModel.FullName ,
                MobileNo = requestModel.MobileNo ,
                WalletUserName = requestModel.WalletUserName,

            };
            #endregion

            #region  Validate Duplicate Record 
            var itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.WalletUserName == requestModel.WalletUserName);
                if(itemWallet is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Wallet Username already exists"
                };
                goto Result;
            }

            itemWallet = _appDbContext.TblWallets.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
                if (itemWallet is not null)
            {
                model = new RegisterWalletResponseModel
                {
                    Message = "Mobile No already exists"
                };
                goto Result;
            }
            #endregion   

            #region RegisterWallet
            _appDbContext.Add(item);
            _appDbContext.SaveChanges();
            #endregion

            model = new RegisterWalletResponseModel
            {
                FullName = requestModel.FullName,
                IsSuccess = true,
                WalleetUserName = requestModel.WalletUserName,
                Message = "Success",
                MobileNo = requestModel.MobileNo,
                WalletId = item.WalletId,
            };
        Result:
            return Ok(model);
        }

    }
}
