Console.WriteLine("Hello World");

//string letter = "C";

//if (letter == "A")
//{
//    Console.WriteLine("run");
//}
//else if (letter == "B")
//{
//    Console.WriteLine("sleep");
//}
//else if (letter == "C")
//{
//    Console.WriteLine("Eat");
//}
//else
//{
//    Console.WriteLine("Invalid Word");
//}

//switch (letter)
//{
//    case "A":
//        Console.WriteLine("Run");
//        break;
//    case "B":
//        Console.WriteLine("Sleep");
//        break;
//    case "C":
//        Console.WriteLine("Eat");
//        break;
//}

Resume resume1 = new Resume();
resume1.Name = "Thein";
resume1.Age = 19;
var result = resume1.IS18();
Console.WriteLine(result);


Resume resume2 = new Resume();
resume2.Name = "Htet";
resume2.Age = 20;

Resume resume3 = new Resume("Aung",18);
Console.ReadLine();


public class Resume
{
    public Resume()
    {
        Name = "None";
        Age = 0;
    }

    public Resume (string name , int age)
    {
        Name = name;
        Age = age;  
    }
    public string Name { get; set; }
    public int Age;
    private bool Is18;

    public bool IS18()
    {
        return Age > 18;
    }

}