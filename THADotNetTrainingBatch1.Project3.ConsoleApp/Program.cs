// See https://aka.ms/new-console-template for more information
using System.Text;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");

Console.Write("ENter the Mobile Number");
string mobileNo = Console.ReadLine()!;



//var response = await client.GetAsync($"https://localhost:7125/api/CheckBalance/{mobileNo}");

//if (response.IsSuccessStatusCode)
//{
//    string json = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(json);
//}

HttpClient client = new HttpClient();

CheckBalanceRequestModel model = new CheckBalanceRequestModel
{
    MobileNo = mobileNo,
};

var json = JsonConvert.SerializeObject(model);
var content = new StringContent(json , Encoding.UTF8 , Application.Json );
var Task1 = client.GetAsync($"https://localhost:7125/api/CheckBalance/{mobileNo}");

var Task2 = client.PostAsync($"https://localhost:7125/api/CheckBalance",content);

var Task3 = client.PostAsync($"https://localhost:7125/api/CheckBalance",content);

await Task.Run(() => Task1);

DateTime startTime = DateTime.Now;
await Task.Run(() => Task1);
await Task.Run(() => Task2);
await Task.Run(() => Task3);
DateTime endTime = DateTime.Now;

var result = endTime - startTime;
Console.WriteLine(result.Milliseconds);

startTime = DateTime.Now;   
await Task.WhenAll(Task1, Task2, Task3);
endTime = DateTime.Now;

result = endTime - startTime;
Console.WriteLine(result.Milliseconds);

if (Task2.Result.IsSuccessStatusCode)
{
   var Josn = await Task2.Result.Content.ReadAsStringAsync();
    Console.WriteLine(Josn);
}
public class CheckBalanceRequestModel
{
    public string MobileNo { get; set; }   
}