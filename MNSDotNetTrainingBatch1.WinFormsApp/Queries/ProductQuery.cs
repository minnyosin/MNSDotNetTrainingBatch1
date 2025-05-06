using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSDotNetTrainingBatch1.WinFormsApp.Quaries
{
    internal class ProductQuery
    {
        public static string GetAllProduct { get; } = @"select ProductCode,
ProductName,
Price, 
Quantity, 
CreatedDateTime,
U.Username as CreatedBy from Tbl_Product P
inner join Tbl_User U on P.CreatedBy = U.Id
inner join Tbl_ProductCategory PC on P.ProductCategoryId = PC.Id";

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
    }
}
