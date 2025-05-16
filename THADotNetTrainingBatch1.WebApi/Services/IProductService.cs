using THADotNetTrainingBatch1.WebApi.Model;

namespace THADotNetTrainingBatch1.WebApi.Services
{
    public interface IProductService
    {
        ResponseModel CreareProduct(ProductModel requestModel);
        ResponseModel DeleteProduct(int id);
        ResponseModel GetProductById(int id);
        ResponseModel GetProducts();
        ResponseModel UpdateProduct(int ProductId, ProductModel requestModel);
    }
}