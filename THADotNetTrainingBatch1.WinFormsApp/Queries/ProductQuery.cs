using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THADotNetTrainingBatch1.WinFormsApp.Queries
{
    internal class ProductQuery
    {
        public static string GetAllProduct { get; } = "select * from Tbl_Product";
        public static string InsertProduct { get; } = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductCode]
           ,[ProductName]
           ,[Price]
           ,[Quantity]
           ,[CreateDateTime]
           ,[CreatedBy]
           )
     VALUES
           (@ProductCode
           ,@ProductName
           ,@Price
           ,@Quantity
           ,@CreatedDateTime
           ,@CreatedBy
           )";
    }
}
