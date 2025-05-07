// See https://aka.ms/new-console-template for more information
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using THADotNetTrainingBatch1.ConsoleApp3;

Console.WriteLine("Hello, World!");
SqlService sqlService = new SqlService();
sqlService.Query<Product>("SELECT * FROM Tbl_Product");
sqlService.Execute("SELECT * FROM Tbl_Product");
sqlService.Execute("SELECT * FROM Tbl_Product");
sqlService.Execute("SELECT * FROM Tbl_Product");
//string query = @"INSERT INTO [dbo].[Tbl_Product]
//           ([ProductCode]
//           ,[ProductName]
//           ,[Price]
//           ,[Quantity]
//           ,[CreateDateTime]
//           ,[CreatedBy]
//           )
//     VALUES
//           (@ProductCode
//           ,@ProductName
//           ,@Price
//           ,@Quantity
//           ,@CreateDateTime
//           ,@CreatedBy
//           )";
//connection.Execute(query, new Product
//{
//    ProductCode = "P011",
//    ProductName = "Pineapple",
//    Price = 2000,
//    Quantity = 30,
//    CreateDateTime = DateTime.Now,
//    CreatedBy = 1 
//});
//var lst = connection.Query<Product>("SELECT * FROM Tbl_Product").ToList();
//foreach (var item in lst)
//{
//    Console.WriteLine(item.ProductId);
//}

public class Product
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public DateTime CreateDateTime { get; set; }

    public int CreatedBy { get; set; }
}