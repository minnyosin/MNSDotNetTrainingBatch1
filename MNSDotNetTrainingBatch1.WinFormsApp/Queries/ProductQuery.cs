using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNSDotNetTrainingBatch1.WinFormsApp.Quaries
{
    internal class ProductQuery
    {
        public static string GetAllProduct { get; } = "select * from Tbl_Product";

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
