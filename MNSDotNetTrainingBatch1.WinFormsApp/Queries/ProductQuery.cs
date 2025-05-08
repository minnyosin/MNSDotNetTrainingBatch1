using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSDotNetTrainingBatch1.WinFormsApp.Quaries
{
    internal class ProductQuery
    {
        public static string GetAllProduct { get; } = @"select ProductId, ProductCode,
ProductName,
Price, 
Quantity, 
CreatedDateTime,
U.Username as CreatedBy,
ModifiedDateTime,
ModifiedBy from Tbl_Product P
left join Tbl_User U on P.CreatedBy = U.Id
left join Tbl_ProductCategory PC on P.ProductCategoryId = PC.Id";

        public static string Detail { get; } = "select * from Tbl_Product where ProductId = @ProductId";

        public static string CreateProduct { get; } = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductName]
           ,[Price]
           ,[Quantity]
           ,[CreatedDateTime]
           ,[CreatedBy])
       VALUES
           (@Name
           ,@Price
           ,@Quantity
           ,@CreatedDate
           ,@CreatedBy)";

        public static string Login { get; } = "select * from Tbl_User where @Username = Username and @Password = Password";

        public static string UpdateProduct { get; } = @"UPDATE [dbo].[Tbl_Product]
   SET [ProductName] = @ProductName
      ,[Price] = @Price
      ,[Quantity] = @Quantity
      ,[ModifiedDateTime] = @ModifiedDate
      ,[ModifiedBy] = @ModifiedBy
 WHERE ProductId = @ProductId";

        public static string DeleteProduct { get; } = "delete from Tbl_product where ProductId = @ProductId";
    }


}
