using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using MNSDotNetTrainingBatch1.TestShared;
using MNSDotNetTrainingBatch1.TestWebApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            //if (lst.Count == 0)
            //{
            //    return new ResponseModel
            //    {
            //        IsSuccess = false,
            //        Message = "Code not found!"
            //    };
            //}
            var model = new ResponseModel
            {
                IsSuccess = lst.Count > 0,
                Message = lst.Count > 0 ? "Successful!" : "Data not found!",
                Data = lst
            };
            return model;
        }

        public ResponseModel GetProductCategoryByPageNo(int pageNo, int pageSize)
        {
            string query = "select * from Tbl_ProductCategory";
            var lst = _dapperService.Query<ProductCategory>(query).Skip((pageNo - 1) * pageSize).Take(pageSize);
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
            if (productCategory.Code == null && string.IsNullOrEmpty(productCategory.Code.Trim()))
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Name cannot be empty!"
                };
            }
            if (productCategory.Name == null && string.IsNullOrEmpty(productCategory.Name.Trim()))
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Name cannot be empty!"
                };
            }

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

        public ResponseModel UpdateProductCategory(ProductCategory productCategory, int id)
        {
            productCategory.Id = id;
            string field = string.Empty;
            if (productCategory.Code != null && !string.IsNullOrEmpty(productCategory.Code.Trim()))
            {
                field += "[Code] = @Code";
            }
            if (productCategory.Name != null && !string.IsNullOrEmpty(productCategory.Name.Trim()))
            {
                field += "[Name] = @Name,";
            }
            if (field.Length == 0)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "No data to update"
                };
            }
            if (field.Length > 0)
            {
                field = field.Substring(0, field.Length - 1);
            }

            ResponseModel model = UpdateProductCategory(productCategory, field);
            return model;
        }
        private ResponseModel UpdateProductCategory(ProductCategory productCategory, string field)
        {
            
            string query = $@"UPDATE [dbo].[Tbl_ProductCategory]
   SET {field}
 WHERE Id = @Id";
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