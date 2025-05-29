using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace THADotNetTrainingBatch1.MvcApp.Controllers
{
    public class WalletController : Controller
    {
        [ActionName("Index")]
        public async Task<IActionResult> WalletIndex()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "MiniWallet",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<WalletModel>("select * from Tbl_Wallet");
            return View("WalletIndex" , lst.ToList());
        }

        public class WalletModel()
        {
            public string WalletUserName {  get; set; } 

            public string MobileNo { get; set; }    
        }
    }
}
