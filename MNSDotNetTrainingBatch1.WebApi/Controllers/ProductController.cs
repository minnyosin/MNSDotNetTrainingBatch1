using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using MNSDotNetTrainingBatch1.Shared;
using MNSDotNetTrainingBatch1.WebApi.Models;

namespace MNSDotNetTrainingBatch1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DapperService _dapperService;

        public ProductController()
        {
            SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "DotNetTrainingBatch1",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };

            _dapperService = new DapperService(_sqlConnectionStringBuilder);
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            string query = "select * from Tbl_Product";
            var lst = _dapperService.Query<ProductModel>(query);
            var data = new
            {
                IsSuccess = true,
                Message = "Success!",
                Data = lst
            };
            return Ok(data);
        }

        [HttpGet("Edit/{Id}")]
        [HttpGet("{Id}")]
        public IActionResult GetProductV2(int Id)
        {
            string query = "select * from Tbl_Product where @ProductId = ProductId";
            var lst = _dapperService.Query<ProductModel>(query, new
            {
                ProductId = Id
            });

            if (lst.Count == 0)
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
                Message = "Success!",
                Data = lst[0]
            };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            product.CreatedDateTime = DateTime.Now;
            product.CreatedBy = 1;

            string query = @"INSERT INTO [dbo].[Tbl_Product]
            ([ProductName]
            ,[Price]
            ,[Quantity]
            ,[CreatedDateTime]
            ,[CreatedBy])
       VALUES
            (@ProductName
            ,@Price
            ,@Quantity
            ,@CreatedDateTime
            ,@CreatedBy)";

            int result = _dapperService.Execute(query, product);
            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Successful" : "Update Failed!"
            };
            return Ok(data);
        }

        [HttpPut]
        public IActionResult CreateOrUpdateProduct()
        {
            return Ok("CreateOrUpdateProduct");
        }

        [HttpPatch]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            product.ModifiedDateTime = DateTime.Now;
            product.ModifiedBy = 1;

            string query = @"UPDATE [dbo].[Tbl_Product]
   SET [ProductName] = @ProductName
      ,[Price] = @Price
      ,[Quantity] = @Quantity
      ,[ModifiedDateTime] = @ModifiedDateTime
      ,[ModifiedBy] = @ModifiedBy
 WHERE [ProductId] = @ProductId";

            int result = _dapperService.Execute(query, product);

            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Success!" : "Update Failed!"
            };

            return Ok(data);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            string query = "delete from Tbl_Product where ProductId = @ProductId";

            int result = _dapperService.Execute(query, new
            {
                ProductId = Id
            });

            var data = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Delete Successful!" : "Delete Failed!"
            };
            
            return Ok(data);
        }
    }

}
