using THADotNetTrainingBatch1;
InventoryService inventoryService = new InventoryService();
Console.WriteLine("Inventory Management system ");
option:
Console.WriteLine("1 : Create Product !");
Console.WriteLine("2 : View Product !" );
Console.WriteLine("3 : UPdate Product !");
Console.WriteLine("4 : Delete Product !");
Console.WriteLine("5 : Exist !");
Console.Write("Input Option : ");
int option = int.Parse(Console.ReadLine()!);
switch(option)
{
    case 1:
        inventoryService.CreateProduct();
        break;
    case 2:
        inventoryService.ViewProduct(); 
        break;
    case 3:
        inventoryService.UpdateProduct();
        break;
    case 4:
        inventoryService.DeleteProduct();
        break;
    case 5:
        Console.WriteLine("Thank For using!");
        goto exist;
    default:
        Console.WriteLine("Invalid opiton!");
        break;
}
goto option;
exist:
Console.ReadLine(); 
