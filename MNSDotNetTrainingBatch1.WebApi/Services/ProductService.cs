using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MNSDotNetTrainingBatch1.Shared;
using MNSDotNetTrainingBatch1.WebApi.Models;

namespace MNSDotNetTrainingBatch1.WebApi.Services
{
    public class ProductService
    {
        private readonly DapperService _dapperService;
        public ProductService()
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
        public ResponseModel GetProduct()
        {
            string query = "select * from Tbl_Product";
            var lst = _dapperService.Query<ProductModel>(query);
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success!",
                Data = lst
            };
            return model;
        }
        public ResponseModel GetProductById(int id)
        {
            string query = "select * from Tbl_Product where @ProductId = ProductId";
            var lst = _dapperService.Query<ProductModel>(query, new
            {
                ProductId = id
            });

            if (lst.Count == 0)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Id not found!"
                };
            }
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success!",
                Data = lst[0]
            };
            return model;
        }
        public ResponseModel CreateProduct(ProductModel requestModel)
        {
            if (!requestModel.ProductName.IsNullOrEmptyV2())
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Name required"
                };
            }
            if (!requestModel.Price.IsNullOrEmptyV2())
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Price required"
                };
            }
            if (!requestModel.Quantity.IsNullOrEmptyV2())
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Price required"
                };
            }

            requestModel.CreatedDateTime = DateTime.Now;
            requestModel.CreatedBy = 1;

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

            int result = _dapperService.Execute(query, requestModel);
            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Create Successful" : "Create Failed!"
            };
            return model;
        }

        public ResponseModel UpdateProduct(int id, ProductModel requestModel)
        {
            requestModel.ProductId = id;
            string fields = string.Empty;

            #region Check Fields
            if (requestModel.ProductName != null && !string.IsNullOrEmpty(requestModel.ProductName.Trim()))
            {
                fields += "[ProductName] = @ProductName,";
            }
            if (requestModel.Price != null && requestModel.Price > 0)
            {
                fields += "[Price] = @Price,";
            }
            if (requestModel.Quantity != null && requestModel.Quantity > 0)
            {
                fields += "[Quantity] = @Quantity,";
            }

            if (fields.Length == 0)
            {
                var response = new ResponseModel
                {
                    IsSuccess = false,
                    Message = "No data to update!"
                };
                return response;
            }
            #endregion

            #region Remove Comma

            if (fields.Length > 0)
            {
                fields = fields.Substring(0, fields.Length - 1);
            }
            #endregion

            ResponseModel model = UpdateProduct(requestModel, fields);

            return model;

        }
        private ResponseModel UpdateProduct(ProductModel requestModel, string fields)
        {
            requestModel.ModifiedDateTime = DateTime.Now;
            requestModel.ModifiedBy = 1;

            string query = $@"UPDATE [dbo].[Tbl_Product]
   SET 
       {fields}
      ,[ModifiedDateTime] = @ModifiedDateTime
      ,[ModifiedBy] = @ModifiedBy
 WHERE ProductId = @ProductId";

            int result = _dapperService.Execute(query, requestModel);

            var model = new ResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Success!" : "Update Failed!"
            };
            return model;
        }

        public ResponseModel DeleteProduct(int id)
        {
            string query = "delete from Tbl_Product where ProductId = @ProductId";

            int result = _dapperService.Execute(query, new
            {
                ProductId = id
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
