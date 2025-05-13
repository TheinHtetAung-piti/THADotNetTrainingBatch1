using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using THADotNetTrainingBatch1.Shared;
using THADotNetTrainingBatch1.WebApi.Model;
using THADotNetTrainingBatch1.WebApi.Services;

namespace THADotNetTrainingBatch1.WebApi.Controllers
{
    //https://Localhost:3000/api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController()
            {
                _productService = new ProductService();
            }
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("Edit/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var model = _productService.GetProductById(id);
            if (!model.IsSuccess )
            {
                return NotFound(model);
            }
            return Ok(model);   
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] ProductModel newProduct)
        {
            var model = _productService.CreareProduct(newProduct);
            return Ok(model);

        }

        [HttpPut]
        [HttpPut("{id}")]
        public IActionResult CreateUpdateProduct([FromBody] ProductModel product,int id)
        {
 //           string query = "select * from Tbl_Product where ProductId = @ProductId";
 //           var lst = _dapperService.Query<ProductModel>(query,
 //               new
 //               {
 //                   ProductId = id
 //               });
 //           if (lst.Count == 0)
 //           {
 //               return NotFound(new
 //               {
 //                   IsSuccess = false,
 //                   Message = "Product Not Found!"
 //               });
 //           }

 //           product.ModifiedBy = 1;
 //           product.ModifiedDateTime = DateTime.Now;
 //           string updQuery = @"UPDATE [dbo].[Tbl_Product]
 //  SET [ProductCode] = @ProductCode
 //     ,[ProductName] = @ProductName
 //     ,[ProductCategory] = @ProductCategory
 //     ,[Price] = @Price
 //     ,[Quantity] = @Quantity
 //     ,[ModifiedDateTime] = @ModifiedDateTime
 //     ,[ModifiedBy] = @ModifiedBy
 //WHERE ProductId = @ProductId";
 //           int result = _dapperService.Execute(updQuery, new { ProductId = id });
 //           var data = new
 //           {
 //               IsSuccess = result > 0,
 //               Message = result > 0 ? "Success" : "Fail",
 //           };
            return Ok("Put");
        }

        [HttpPatch("{ProductId}")]
        public IActionResult PatchProduct(int ProductId , [FromBody] ProductModel product)
        {
            var model = _productService.UpdateProduct(ProductId , product);
            return Ok(model);
        }

        [HttpDelete("{ProductId}")]

        public IActionResult DeleteProduct(int ProductId)
        {
            var model = _productService.DeleteProduct(ProductId);
            return Ok(model);
        }
    }
}
