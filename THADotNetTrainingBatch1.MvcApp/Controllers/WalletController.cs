using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using THADotNetTrainingBatch1.Shared;

namespace THADotNetTrainingBatch1.MvcApp.Controllers
{
    public class WalletController : Controller
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
        
        [ActionName("Index")]
        public async Task<IActionResult> WalletIndex()
        {

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<WalletModel>("select * from Tbl_Wallet");
            return View("WalletIndex", lst.ToList());
        }

        [ActionName("HistoryIndex")]
        public async Task<IActionResult> WalletHistroyIndex()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<TranscationModel>("select * from Tbl_Transcation");
            return View("HistoryIndex" , lst.ToList());
        }

        //[HttpPost]
        //[ActionName("HistroyIndex")]
        //public async Task<IActionResult> WalletHistoryIndex()
        //{

        //    using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        //    db.Open();
        //    var lst = await db.QueryAsync<TranscationModel>("select * from Tbl_Transcation");
        //    return View("HistroyIndex", lst.ToList());
        //}
        //[HttpGet]
        //[ActionName("HistroyIndex")]
        //public async Task<IActionResult> WalletHistoryIndex()
        //{

        //    using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        //    db.Open();
        //    var lst = await db.QueryAsync<WalletModel>("select * from Tbl_Transcation");
        //    return View("HistroyIndex", lst.ToList());
        //}

        [ActionName("Create")]
        public IActionResult WalletCreate()
        {
            return View("WalletCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> WalletCreateAsync(WalletModel requestModel)
        {
            bool isSuccess = false;
            string message;
            if (requestModel.WalletUserName.IsNullOrEmptyV2())
            {
                message = "need to fill WalletUserName";
                goto End;

            }

            if (requestModel.FullName.IsNullOrEmptyV2())
            {
                message = "need to fill Full Name";
                goto End;
            }

            if (requestModel.MobileNo.IsNullOrEmptyV2())
            {
                message = "need to fill MobileNo";
                goto End;
            }

            if (requestModel.Balance <= 0)
            {
                message = "YOur amount is invalid";
                goto End;
            }

            string getQuery = "select * from Tbl_Wallet";
            string query = @"INSERT INTO [dbo].[Tbl_Wallet]
           ([WalletUserName]
           ,[FullName]
           ,[MobileNo]
           ,[Balance])
     VALUES
           (@WalletUserName
           ,@FullName
           ,@MobileNo
           ,@Balance)";
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {

                db.Open();
                var data = await db.QueryAsync<WalletModel>(getQuery);

                var check = data.FirstOrDefault(x => x.WalletUserName == requestModel.WalletUserName);
                if (check != null)
                {
                    message = "UserName already exist";
                    goto End;
                }

                check = data.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
                if (check != null)
                {
                    message = "Mobile NO already exist";
                    goto End;
                }

                var result = await db.ExecuteAsync(query, requestModel);

                isSuccess = result > 0;
                message = isSuccess ? "Success" : "Fail";
            }


        End:
            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> WalletEditAsync(int id)
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = @"SELECT [WalletId]
      ,[WalletUserName]
      ,[FullName]
      ,[MobileNo]
      ,[Balance]
  FROM [dbo].[Tbl_Wallet]
  where WalletId  = @WalletId";
            var model = await db.QueryFirstOrDefaultAsync<WalletModel>(query, new
            {
                WalletId = id
            });
            if (model is null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found";
                RedirectToAction("Index");
            }
            return View("WalletEdit", model);
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> WalletUpdate(int id,WalletModel requestModel)
        {
            bool isSuccess = false;
            string message;
            requestModel.WalletId = id;
            if (requestModel.WalletUserName.IsNullOrEmptyV2())
            {
                message = "need to fill WalletUserName";
                goto end;

            }

            if (requestModel.FullName.IsNullOrEmptyV2())
            {
                message = "need to fill Full Name";
                goto end;
            }

            if (requestModel.MobileNo.IsNullOrEmptyV2())
            {
                message = "need to fill MobileNo";
                goto end;
            }

            string getQuery = "select * from Tbl_Wallet";
            string query = @"UPDATE [dbo].[Tbl_Wallet]
   SET [WalletUserName] = @WalletUserName
      ,[FullName] = @FullName
      ,[MobileNo] = @MobileNo

 WHERE WalletId = @WalletId";

            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                var data = await db.QueryAsync<WalletModel>(getQuery);

                var check = data.FirstOrDefault(x => x.WalletUserName == requestModel.WalletUserName.Trim());
                if (check != null)
                {
                    message = "UserName already exist";
                    goto end;
                }

                check = data.FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);
                if (check != null)
                {
                    message = "Mobile NO already exist";
                    goto end;
                }


                var result = await db.ExecuteAsync(query, requestModel);
                isSuccess = result > 0;
                message = isSuccess ? "Success" : "fail";
            }
        

            end:
            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> WalletDeleteAsync(int id)
        {
          
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = @"SELECT [WalletId]
      ,[WalletUserName]
      ,[FullName]
      ,[MobileNo]
      ,[Balance]
  FROM [dbo].[Tbl_Wallet]
  where WalletId  = @WalletId";
            var model = await db.QueryFirstOrDefaultAsync<WalletModel>(query, new
            {
                WalletId = id
            });
            if (model is null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found";
                RedirectToAction("Index");
            }
            string deleteQuery = @"DELETE FROM [dbo].[Tbl_Wallet]    
                                    WHERE WalletId = @WalletId";

            int result = await db.ExecuteAsync(deleteQuery, new 
            {
                WalletId = id
            });

            if(result == 0 )
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found";
                RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Transfer")]
        public IActionResult WalletTransfer()
        {
            return View("WalletTransfer");
        }

        [HttpPost]
        [ActionName("Transfer")]
        public async Task<IActionResult> WalletTransfer(TranscationModel requestModel)
        {
            bool isSuccess = false;
            string message = string.Empty;
            if(!requestModel.FromMobileNo.IsNullOrEmptyV2()) 
             {
                message = "From Mobile No is Required";
                goto Result;
             }
            if(!requestModel.ToMobileNo.IsNullOrEmptyV2())
            {
                message = "To mobile No is required";
                goto Result;
            }
            if(requestModel.Amount <= 0 )
            {
                message = "Amount is invalid";
                goto Result;
            }

            using(IDbConnection db =  new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string getQuery = "select * from Tbl_Wallet";

                var data = await db.QueryAsync < WalletModel>(getQuery);

                var checkFrom = data.FirstOrDefault(x => x.MobileNo == requestModel.FromMobileNo);
                if(checkFrom is null )
                {
                    message = "From Mobile No is Invalid";
                    goto Result;
                }

                var checkTo = data.FirstOrDefault(x => x.MobileNo == requestModel.ToMobileNo);
                if(checkTo is null )
                {
                    message = "To Mobile No is Invalid";
                    goto Result;
                }

                if(checkFrom!.Balance - 10000 < requestModel.Amount )
                {
                    message = "Insufficient Amount";
                    goto Result;
                }


                checkFrom.Balance -= requestModel.Amount;

                checkTo.Balance += requestModel.Amount;

                string updQuery = @"INSERT INTO [dbo].[Tbl_Transcation]
           ([TranscationId]
           ,[TranscationNo]
           ,[FromMobileNo]
           ,[ToMobileNo]
           ,[Amount]
           ,[TransctationDate])
     VALUES
           (@TranscationId
           ,@TranscationNo
           ,@FromMobileNo
           ,@ToMobileNo
           ,@Amount
           ,@TransctationDate)";

                TranscationModel responseModel = new TranscationModel()
                {
                    FromMobileNo = checkFrom.MobileNo,
                    ToMobileNo = checkTo.MobileNo,
                    Amount = requestModel.Amount,
                    TransctationDate = DateTime.Now,
                    TranscationNo = DateTime.Now.ToString("yyyyMMdd_hhmmss_fff"),
                    TranscationId = Ulid.NewUlid().ToString(),
                };

                int result = await db.ExecuteAsync(updQuery, responseModel);

                isSuccess = result > 0;
                message = isSuccess ? "Transfer Success" : "Transter Fail";
            }

        Result:

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return View("TranscationHistory",requestModel);
        }

        

        public class WalletModel()
        {
            public int WalletId { get; set; }

            public string WalletUserName {  get; set; } 

            public string FullName { get; set; }    

            public decimal Balance { get; set; }

            public string MobileNo { get; set; }    
        }

        public class TranscationModel()
        {
            public string TranscationId { get; set; } = null!;

            public string TranscationNo { get; set; } = null!;

            public string FromMobileNo { get; set; } = null!;

            public string ToMobileNo { get; set; } = null!;

            public decimal Amount { get; set; }

            public DateTime TransctationDate { get; set; }
        }
    }
}
