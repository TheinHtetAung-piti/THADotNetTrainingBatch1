using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THADotNetTrainingBatch1.WinFormsApp.Queries
{
    internal class ProductQuery
    {
        public static string GetAllProduct { get; } = @"select ProductId,
ProductCode,
ProductName,
Category,
Price, 
Quantity, 
U.Name as CreatedBy 
from Tbl_Product P 
left join Tbl_User U on P.CreatedBy = U.Id
left join Tbl_Category PC on PC.Id = P.ProductCategory";
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
