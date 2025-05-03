// See https://aka.ms/new-console-template for more information
using System.Data;
using ConsoleApp2;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

HomeworkService homewrokService = new HomeworkService();
Console.WriteLine("Welcome From Homework Services!");
Console.WriteLine("1:Create");
Console.WriteLine("2:Update");
Console.WriteLine("3:View All");
Console.WriteLine("4:View Detail");
Console.WriteLine("5:Login");
Console.WriteLine("6:Delete");

beforeOption:
Console.Write("Enter Option : ");
string inputOption = Console.ReadLine()!;
bool resultOption = int.TryParse(inputOption, out int option);
if (!resultOption)
{
    Console.WriteLine("Invalid option");
    goto beforeOption;
}
switch(option)
{
    case 1:
        homewrokService.Create();
        break;
    case 2:
        homewrokService.Update();
        break;
    case 3:
        homewrokService.Read();
        break;
    case 4:
        homewrokService.ReadDetail();
        break;
    case 5:
        homewrokService.delete();
        break;
    case 6:
        homewrokService.Login();
        break;
    case 7:
        Console.WriteLine("Thank You for using!");
        goto exit;
}
goto beforeOption;
exit:
Console.WriteLine("");
