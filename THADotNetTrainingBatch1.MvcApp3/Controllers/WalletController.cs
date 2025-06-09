using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace THADotNetTrainingBatch1.MvcApp3.Controllers
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
        public IActionResult WalletIndex()
        {
            return View("WalletIndex");
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> WallerList()
        {
            try
            {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<WalletModel>("select * from Tbl_Wallet");
            return Json(new { IsSuccess = true , Message = "Success" , Data = lst });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Message = ex.ToString() });
            }
        }
    }

    public class WalletModel()
    {
        public int WalletId { get; set; }

        public string WalletUserName { get; set; }

        public string FullName { get; set; }

        public decimal Balance { get; set; }

        public string MobileNo { get; set; }
    }
}
