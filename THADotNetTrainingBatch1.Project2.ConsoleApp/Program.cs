// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using THADotNetTrainingBatch1.Assi.Database.Models;

AppDbContext db = new AppDbContext();

Console.WriteLine("Hello, World!");

string jsonStr = File.ReadAllText("DreamDictionary.json");
var model = JsonConvert.DeserializeObject<DreamDictionaryResopnseModel>(jsonStr);

var lst = model!.BlogHeader.ToList();
var lst1 = model.BlogDetail.ToList();

foreach (var item in lst)
{
    var blogheader = new TblBlogHeader
    {
        BlogTitle = item.BlogTitle,
    };
    db.TblBlogHeaders.Add(blogheader);
    db.SaveChanges();
}

foreach (var item in lst1)
{
    var blogDetail = new TblBlogDetail
    {
        BlogId = item.BlogId,
        BlogContent = item.BlogContent,
    };
    db.TblBlogDetails.Add(blogDetail);
    db.SaveChanges();
}
Console.ReadLine();


public class DreamDictionaryResopnseModel
{
    public Blogheader[] BlogHeader { get; set; }
    public Blogdetail[] BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string BlogContent { get; set; }
}
