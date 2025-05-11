using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using THADotNetTrainingBatch1.Shared;
using THADotNetTrainingBatch1.WebApi.Model;

namespace THADotNetTrainingBatch1.WebApi.Controllers
{
    //https://Localhost:3000/api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public ProductController()
            {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            { 
                DataSource = ".",
                InitialCatalog = "DotNetTrainingBatch1",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            _dapperService = new DapperService(sqlConnectionStringBuilder);
            }
        [HttpGet]
        public IActionResult GetProduct()
        {
        var lst = _dapperService.Query<ProductModel>("select * from Tbl_Product");
            var data = new
            {
                IsSuccess = true,
                Message = "Success",
                Data = lst
            };
            return Ok(data); 
        }

        [HttpGet("Edit/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            string query = "select * from Tbl_Product where ProductId = @ProductId";
            var lst = _dapperService.Query<ProductModel>(query,
                new { 
                        ProductId = id
                    });

            if (lst.Count == 0 )
            {
                return NotFound(new
                {
                    IsSuccess = false,
                    Message = "Product Not Found!"
                });
            }
            var data = new
            {
                IsSuccess = true,
                Message = "Success",
                Data = lst
            };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductModel newProduct)
        {
            newProduct.CreateDateTime = DateTime.Now;
            newProduct.CreatedBy = 1;
            string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductCode]
           ,[ProductName]
           ,[ProductCategory]
           ,[Price]
           ,[Quantity]
           ,[CreateDateTime]
           ,[CreatedBy])
     VALUES
           (@ProductCode
           ,@ProductName
           ,@ProductCategory
           ,@Price
           ,@Quantity
           ,@CreateDateTime
           ,@CreatedBy)";
            int result = _dapperService.Execute(query, newProduct);
            var data = new
            {
                IsSuccess = result > 0 ,
                Message = result > 0 ? "Success" : "Fail",
            };
            return Ok(data);
        }

        [HttpPut]
        [HttpPut("{id}")]
        public IActionResult PutProduct([FromBody] ProductModel product,int id)
        {
            string query = "select * from Tbl_Product where ProductId = @ProductId";
            var lst = _dapperService.Query<ProductModel>(query,
                new
                {
                    ProductId = id
                });
            if (lst.Count == 0)
            {
                return NotFound(new
                {
                    IsSuccess = false,
                    Message = "Product Not Found!"
                });
            }

            product.ModifiedBy = 1;
            product.ModifiedDateTime = DateTime.Now;
            string updQuery = @"UPDATE [dbo].[Tbl_Product]
   SET [ProductCode] = @ProductCode
      ,[ProductName] = @ProductName
      ,[ProductCategory] = @ProductCategory
      ,[Price] = @Price
      ,[Quantity] = @Quantity
      ,[ModifiedDateTime] = @ModifiedDateTime
      ,[ModifiedBy] = @ModifiedBy
 WHERE ProductId = @ProductId";
            int result = _dapperService.Execute(updQuery, new { ProductId = id });
            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success" : "Fail",
            };
            return Ok(data);
        }

        [HttpPatch]
        public IActionResult PatchProduct()
        {

            return Ok("PatchProduct");    
        }

        [HttpDelete]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            string query = "select * from Tbl_Product where ProductId = @ProductId";
            var lst = _dapperService.Query<ProductModel>(query,
                new
                {
                    ProductId = id
                });
            if (lst.Count == 0)
            {
                return NotFound(new
                {
                    IsSuccess = false,
                    Message = "Product Not Found!"
                });
            }
            string delQuery = @"delete from Tbl_Product where ProductId = @ProductId";
            int result = _dapperService.Execute(delQuery, new
            {
                ProductId = id
            });
            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success" : "Fail",
            };
            return Ok(data);


        }
    }
}
