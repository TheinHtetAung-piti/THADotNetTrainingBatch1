// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonStr = File.ReadAllText("DreamDictionary.json");
var model = JsonConvert.DeserializeObject<DreamDictionaryResopnseModel>(jsonStr);

model.BlogDetail.Where(x => x.BlogId == 1).ToList();
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
