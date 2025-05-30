using System.Data;
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
            return View("WalletIndex" , lst.ToList());
        }

        [ActionName("Create")]
        public IActionResult WalletCreate()
        {
            return View("WalletCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> WalletCreateAsync(WalletModel requestModel )
        {

          
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
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var result = await db.ExecuteAsync(query, requestModel);

            bool isSuccess = result > 0;
            string message = isSuccess ? "Success" : "Fail";

            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;

            return RedirectToAction("WalletCreate");
        }


        public class WalletModel()
        {

            public string WalletUserName {  get; set; } 

            public string FullName { get; set; }    

            public decimal Balance { get; set; }

            public string MobileNo { get; set; }    
        }
    }
}
