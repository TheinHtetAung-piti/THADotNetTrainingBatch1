using Microsoft.Data.SqlClient;
using THADotNetTrainingBatch1.Shared;
using THADotNetTrainingBatch1.WebApi.Model;

namespace THADotNetTrainingBatch1.WebApi.Services
{
    //Business Logic Layer + Data Access Layer 

    // Request => Request Model
    // Response => Model
    public class ProductService
    {
        private readonly DapperService _dapperService;

        public ProductService()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "DotNetTrainingBatch1",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true,
            };
            _dapperService = new DapperService(sqlConnectionStringBuilder);
        }

        //List
        public ResponseModel GetProducts()
        {
            var lst = _dapperService.Query<ProductModel>("select * from Tbl_Product");
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success",
                Data = lst
            };
            return model;
        }

        public ResponseModel GetProductById(int id)
        {

            string query = "select * from Tbl_Product where ProductId = @ProductId";
            var lst = _dapperService.Query<ProductModel>(query,
                new
                {
                    ProductId = id
                });

            if (lst.Count == 0)
            {
                return (new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Product Not Found!"
                });
            }
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success",
                Data = lst[0],
            };
            return model;
        }

        public ResponseModel CreareProduct(ProductModel requestModel)
        {
            requestModel.CreateDateTime = DateTime.Now;
            requestModel.CreatedBy = 1;
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
            int result = _dapperService.Execute(query, requestModel);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success" : "Fail",
            };
            return model;
        }

        public ResponseModel UpdateProduct(int ProductId , ProductModel requestModel)
        {
            requestModel.ProductId = ProductId;
            string field = string.Empty;


            if (requestModel.ProductName != null && !string.IsNullOrEmpty(requestModel.ProductName.Trim()))
            {
                field += "[ProductName] = @ProductName,";
            }
            if (requestModel.ProductCategory != null && string.IsNullOrEmpty(requestModel.ProductCategory.Trim()))
            {
                field += "[ProductCategory] = @ProductCategory,";
            }
            if (requestModel.Price != null && requestModel.Price > 0)
            {
                field += "[Price] = @ Price,";
            }
            if (requestModel.Quantity != null && requestModel.Quantity > 0)
            {
                field += "[Quantity] = @Quantity,";
            }

            if (field.Length == 0)
            {
                return (new ResponseModel
                {
                    IsSuccess = false,
                    Message = "No field to update"
                });
            }

            if (field.Length > 0)
            {
                field = field.Substring(0, field.Length - 1);
            }
            string query = $@"UPDATE [dbo].[Tbl_Product]
   SET 
        {field}
      ,[ModifiedDateTime] = @ModifiedDateTime
      ,[ModifiedBy] = @ModifiedBy
 WHERE ProductId = @ProductId";

            int result = _dapperService.Execute(query, requestModel);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success" : "fail",
            };
            return model;
        }

        public ResponseModel DeleteProduct(int id )
        {
            string query = "select * from Tbl_Product where ProductId = @ProductId";
            var lst = _dapperService.Query<ProductModel>(query,
                new
                {
                    ProductId = id
                });
            if (lst.Count == 0)
            {
                return (new ResponseModel
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
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Success" : "Fail",
            };
            return model;

        }
    }
}
