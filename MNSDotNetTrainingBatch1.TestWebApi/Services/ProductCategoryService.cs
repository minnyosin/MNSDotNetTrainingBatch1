using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using MNSDotNetTrainingBatch1.TestShared;
using MNSDotNetTrainingBatch1.TestWebApi.Models;

namespace MNSDotNetTrainingBatch1.TestWebApi.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IDapperService _dapperService;

        public ProductCategoryService(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }
        public ResponseModel GetProductCategory()
        {
            string query = "select * from Tbl_ProductCategory";
            var lst = _dapperService.Query<ProductCategory>(query);
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Successful!",
                Data = lst
            };
            return model;
        }
        public ResponseModel GetDetailedProductCategory(string code)
        {
            string query = "select * from Tbl_ProductCategory where Code = @Code";
            var lst = _dapperService.Query<ProductCategory>(query, new ProductCategory
            {
                Code = code
            });

            if (lst.Count == 0)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Code not found!"
                };

            }

            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Successful!",
                Data = lst
            };
            return model;
        }

        public ResponseModel CreateProductCategory(ProductCategory productCategory)
        {
            string query = @"INSERT INTO [dbo].[Tbl_ProductCategory]
           ([Code]
           ,[Name])
     VALUES
           (@Code
           ,@Name)";
            int result = _dapperService.Execute(query, productCategory);

            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Insert Successful" : "Insert Failed!"
            };
            return model;
        }
        public ResponseModel UpdateProductCategory(ProductCategory productCategory, string code)
        {
            productCategory.Code = code;
            string query = @"UPDATE [dbo].[Tbl_ProductCategory]
   SET [Name] = @Name
 WHERE Code = @Code";
            int result = _dapperService.Execute(query, productCategory);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Successful!" : "Update Failed!"
            };
            return model;
        }
        public ResponseModel DeleteProductCategory(string code)
        {
            string query = "delete from Tbl_ProductCategory where Code = @Code";
            int result = _dapperService.Execute(query, new ProductCategory
            {
                Code = code
            });
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Delete Successful!" : "Delete Failed!"
            };
            return model;
        }
    }
}
