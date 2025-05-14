using MNSDotNetTrainingBatch1.WebApi.Models;

namespace MNSDotNetTrainingBatch1.WebApi.Services
{
    public interface IProductService
    {
        ResponseModel CreateProduct(ProductModel requestModel);
        ResponseModel DeleteProduct(int id);
        ResponseModel GetProduct(int pageNo, int pageSize);
        ResponseModel GetProducts();
        ResponseModel GetProductById(int id);
        ResponseModel UpdateProduct(int id, ProductModel requestModel);
    }
}