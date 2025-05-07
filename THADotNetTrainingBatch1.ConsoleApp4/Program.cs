// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using THADotNetTrainingBatch1.ConsoleApp4;
using THADotNetTrainingBatch1.Shared;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
var lst = db.ProductCategories.ToList();

foreach (var item in lst)
{
    Console.WriteLine(item.CategoryName);
}

db.ProductCategories.Add(new ProductCategory
{
    ProductCategoryId = 2,
    ProductCategoryCode = "P002",
    CategoryName = "Vegetable"
});
//AdoDotNetService service = new AdoDotNetService(
//    new SqlConnectionStringBuilder
//    {
//        DataSource = ".",
//        InitialCatalog = "DotNetTrainingBatch1",
//        UserID = "sa",
//        Password = "sa@123",
//        TrustServerCertificate = true,
//    });
//var lst = service.QueryV2<Product>("SELECT * FROM Tbl_Product");
//foreach (var item in lst )
//{
//    Console.WriteLine(item.ProductName);
//}

public class Product
{
    public int ProductID { get; set; }

    public string ProductName { get; set; } 

    public string ProductCode { get; set; }

    public double Price { get; set; }   

    public int Quantity { get; set; }   

    public DateTime CreateDateTime { get; set; }
}
//service.Execute("Query", new SqlParameter("@Test", "Test"));
//service.Query("Query");
//Console.ReadLine();
