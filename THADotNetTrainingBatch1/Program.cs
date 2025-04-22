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

//Resume resume1 = new Resume();
//resume1.Name = "Thein";
//resume1.Age = -12;
//var result = resume1.IS18();
//Console.WriteLine(result);


//Resume resume2 = new Resume();
//resume2.Name = "Htet";
//resume2.Age = 20;

//Resume resume3 = new Resume("Aung",18);
//Console.ReadLine();


//public class Resume
//{
//    public Resume()
//    {
//        Name = "None";
//        Age = 0;
//    }

//    public Resume (string name , int age)
//    {
//        Name = name;
//        Age = age;  
//    }
//    private int age;
//    public string Name { get; set; }
//    public int Age
//    {
//        get
//        {
//            return age;
//        }
//         set
//        {
//            if (value <= 0 && value > 100)
//            {
//                age = value;
//            }
//            else
//            {
//                Console.WriteLine("Invalind age ");
//            }
//        }

//    }
//    private bool Is18;

//    public bool IS18()
//    {
//        return Age > 18;
//    }

//}
//string[] name = {};
//Console.WriteLine(name.FirstOrDefault());

//int[] numbers = { 9, 5, 4, 6, 7, 1, 2, 3, 4, 5 };
//var list = numbers.Where(x => x % 2 == 0);
//foreach (var even in list)
//{
//    Console.WriteLine(even);
//}
//var squares = numbers.Select(x => x * x);
//foreach (var square in squares)
//{
//    Console.WriteLine(square);
//}
//Console.WriteLine(numbers.Count());
//Console.WriteLine(numbers.FirstOrDefault());
//Console.WriteLine(numbers.Sum());
//Console.WriteLine(numbers.Average());
//Console.WriteLine(numbers.Max());
//Console.WriteLine(numbers.Min());
//Console.WriteLine(numbers.Order());
//foreach (int number in numbers)
//{
//    if (number % 2 == 0)
//    {
//        Console.WriteLine(number);
//    }

//}

//var newNum = numbers.Where(x => x % 2 == 0);
//foreach (int number in newNum)
//{ 
//    Console.WriteLine(number); 
//}

//double value1 = 12345.444444;
//Console.WriteLine(value1.ToString("N3"));
//Console.WriteLine(value1.ToString("E"));
//Console.WriteLine(value1.ToString("F"));
//Console.WriteLine(value1.ToString("P"));
//Console.WriteLine(value1.ToString("C"));
//Employee employee1 = new Employee();
//employee1.Speaking();
//public class Human
//{
//    public void Speaking()
//    {
//        Console.WriteLine("Hello");
//    }
//}

//public class Employee : Human
//{
//    public string Name;

//}
//Add add = new Add();
//var result = add.Result(1, 2);
//Console.WriteLine(result);
//Console.WriteLine(add.Result(2.2, 4.4));
//public class Add
//{

//    public int Result(int x, int y)
//    { return x + y; }
//    public double Result(double x, double y)
//    {
//        return x + y;
//    }
//}

//Dog dog = new Dog();
//dog.Speak();
//Animal animal = new Animal();
//animal.Speak(); 
//public class Animal
//{
//    public virtual void Speak()
//    {
//        Console.WriteLine("The animal is speaking");
//    }
//}

//public class Dog : Animal
//{
//    public override void Speak()
//    {
//        Console.WriteLine("The dog is barking");
//    }
//}

//public interface Features
//{
//    public void create();
//    public void update();   
//    public void delete();
//    public void read();

//}

//public class Kapay : Features
//{
//    public void create()
//    {
//        throw new NotImplementedException();
//    }

//    public void delete()
//    {
//        throw new NotImplementedException();
//    }

//    public void read()
//    {
//        throw new NotImplementedException();
//    }

//    public void update()
//    {
//        throw new NotImplementedException();
//    }
//}


