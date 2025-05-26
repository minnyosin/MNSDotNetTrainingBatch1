using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MNSDotNetTrainingBatch1.TestShared;
using MNSDotNetTrainingBatch1.TestWebApi.Models;

namespace MNSDotNetTrainingBatch1.TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        DapperService dapperService = new DapperService(new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch1",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        });

        [HttpGet]
        public IActionResult GetProductCategory()
        {
            string query = "select * from Tbl_ProductCategory";
            var lst = dapperService.Query<ProductCategory>(query);
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Successful!",
                Data = lst
            };
            return Ok(model);
        }

        [HttpGet("{code}")]
        public IActionResult GetDetailedProductCategory(string code)
        {
            string query = "select * from Tbl_ProductCategory where Code = @Code";
            var lst = dapperService.Query<ProductCategory>(query, new
            {
                Code = code
            });

            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Successful!",
                Data = lst
            };
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateProductCategory([FromBody] ProductCategory productCategory)
        {
            string query = @"INSERT INTO [dbo].[Tbl_ProductCategory]
           ([Code]
           ,[Name])
     VALUES
           (@Code
           ,@Name)";
            int result = dapperService.Execute(query, productCategory);

            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Insert Successful" : "Insert Failed!"
            };
            return Ok(model);
        }

        //[HttpPut]
        [HttpPatch("{code}")]
        public IActionResult UpdateProductCategory([FromBody] ProductCategory productCategory, string code)
        {
            productCategory.Code = code;
            string query = @"UPDATE [dbo].[Tbl_ProductCategory]
   SET [Name] = @Name
 WHERE Code = @Code";
            int result = dapperService.Execute(query, productCategory);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Successful!" : "Update Failed!"
            };
            return Ok(model);
        }

        [HttpDelete("{code}")]
        public IActionResult DeleteProductCategory(string code)
        {
            string query = "delete from Tbl_ProductCategory where Code = @Code";
            int result = dapperService.Execute(query, new ProductCategory
            {
                Code = code
            });
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Delete Successful!" : "Delete Failed!"
            };
            return Ok(model);
        }
    }
}
