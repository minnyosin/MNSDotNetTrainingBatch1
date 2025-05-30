using MNSDotNetTrainingBatch1.TestWebApi.Models;

namespace MNSDotNetTrainingBatch1.TestWebApi.Services
{
    public interface IProductCategoryService
    {
        ResponseModel CreateProductCategory(ProductCategory productCategory);
        ResponseModel DeleteProductCategory(string code);
        ResponseModel GetDetailedProductCategory(string code);
        ResponseModel GetProductCategory();
        ResponseModel UpdateProductCategory(ProductCategory productCategory, int id);
        ResponseModel GetProductCategoryByPageNo(int pageNo, int pageSize);
    }
}