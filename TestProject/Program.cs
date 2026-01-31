using System;
// string? inStr = Console.ReadLine();
// if (inStr != null)
// {
//     Console.WriteLine(inStr);
// }

// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Введите первое число: ");
//         string? input1 = Console.ReadLine();
//         int a = int.Parse(input1!);

//         Console.Write("Введите второе число: ");
//         string? input2 = Console.ReadLine();
//         int b = int.Parse(input2!);

//         int product = a * b;

//         Console.WriteLine("Произведение: " + product);
//     }
// }


// using System;

// string? x = Console.ReadLine();
// if (x != null)
// {
//     int b = int.Parse(x);s
//     var z = SumOfSquares(b);

// Console.WriteLine(z);


// // Метод SumOfSquares
// int SumOfSquares(int x)
// {
//     var result = x + 10;

//     return result;
// }
// }

// using System;

// var car = new Car();
// car.Start();

// class Car
// {
//   public void   Start()
// {
//          Console.WriteLine("Start car engine!");

// }    
// }
// var  s= "Hello, C#!";
// var b=123;
// var c= true;

// Console.WriteLine(s);
// Console.WriteLine(b);
// Console.WriteLine(c);

// static void PrintDefaultValue<T>(T val)
// {
//     Console.WriteLine($"Тип аргумента val: {val.GetType()}");
//     Console.WriteLine($"Значение по умолчанию для типа {val.GetType()}: {default(T)}");
//     Console.WriteLine($"Текущее значение аргумента val: {val}");
// }
// PrintDefaultValue<int>(5);

// Console.WriteLine();

// PrintDefaultValue<bool>(true);

// internal class Program
// {
//     static void Main(string[] args)
//     {
//         // Создание и инициализация с помощью оператора new
//         Person p1 = new Person() { Name = "John" };

//         // Создание и инициализация через присвоение значения другой переменной
//         Person p2 = p1;

//         // Изменим значение свойства Name у p1
//         p1.Name = "Mary";

//         // Выведем значение Name у p1 и p2
//         Console.WriteLine(p1.Name); // Mary
//         Console.WriteLine(p2.Name); // Mary

//         PrintName(p2);
//         Console.WriteLine(p1.Name);
//     }

//     private static void PrintName(Person p)
//     {
//         Console.WriteLine($"Name is: {p.Name}");

//         p.Name = string.Empty;
//     }
// }

// class Person
// {
//     public string Name { get; set; } = string.Empty;
// }

// static int? GetValue(bool flag)
// {
//     if (flag == true)
//         return 1000;
//     else
//         return null;
// }

// static void Main(string[] args)
// {
//     int test1 = GetValue(true) ?? 123;
//     Console.WriteLine(test1); // 1000

//     int test2 = GetValue(false) ?? 123;
//     Console.WriteLine(test2); // 123
// }

// using System;
// using System.Runtime;

// var name = Console.ReadLine();
// var age = int.Parse(Console.ReadLine());

// var p1 = new Person { Name = name, Age = age };
// var p2 = ModifyPersonsName(p1);

// Console.WriteLine($"{p1.Name}, {p1.Age}");
// Console.WriteLine($"{p2.Name}, {p2.Age}");

// Person ModifyPersonsName(Person person)
// {
//         return new Person
//         {
//             Name = $"[{person.Name}]",
//             Age = person.Age
//         };
    
// }

// class Person
// {
//     public string Name { get; set; } = string.Empty;
//     public int Age { get; set; }
// }

// using System;
// using System.Text.Json;

// var json = Console.ReadLine();
// var person = JsonSerializer.Deserialize<Person>(json);

// Console.WriteLine(GetPersonAge(person));

// int GetPersonAge(Person person)
// {
//     if (person.Age != null)
//         return person.Age.Value; // или (int)person.Age

//     return -1;
// }

// class Person
// {
//     public string Name { get; set; } = string.Empty;
//     public int? Age { get; set; }
// }

// using A.B;
// using A.C;
// using System;

// var nameA = Console.ReadLine();
// var nameB = Console.ReadLine();

// var pa = new PersonA() { Name = nameA };
// var pb = new PersonB() { Name = nameB };

// Console.WriteLine(pa.Name);
// Console.WriteLine(pb.Name);

// namespace A.B
// {
//     class PersonA 
//     { 
//         public string Name { get; set; } 
//     }
// }

// namespace A.C

// {
//     class PersonB 
//     { 
//         public string Name { get; set; } 
//     }
// }

using System;

// var number1 = int.Parse(Console.ReadLine());
// var number2 = int.Parse(Console.ReadLine());
// bool? flag = Console.ReadLine() == "null" ? null : true;

// var result = AdditionOrMultiplication(number1, number2, flag);
// Console.WriteLine(result);

// int AdditionOrMultiplication(int num1, int num2, bool? flag)
// {
//     if (flag == null)
//         return num1 + num2;   // если flag == null → сложение

//     return num1 * num2;       // если flag != null → умножение
// }

// using System;

// var isNumber1 = int.TryParse(Console.ReadLine(), out int number1);
// var isNumber2 = int.TryParse(Console.ReadLine(), out int number2);
// var isNumber3 = int.TryParse(Console.ReadLine(), out int number3);



// // Добавьте сюда свой код
// if (!isNumber1 || !isNumber2 || !isNumber3)
// {
//     Console.WriteLine("Ошибка!");
// }
// else
// {
//     var max = number1;

//     if (number2 > max)
//         max = number2;

//     if (number3 > max)
//         max = number3;

//     Console.WriteLine(max);
// }

// using System;

// const string AdminLogin = "admin";
// const string AdminPassword = "qwerty123";

// var login = Console.ReadLine();
// var password = Console.ReadLine();

// if (login == AdminLogin)
// {
//     if (password == AdminPassword)
//     {
//         Console.WriteLine("Access is allowed");
//     }
//     else
//     {
//       Console.WriteLine("Access denied");  
//     }
// }
// else
//     {
//       Console.WriteLine("Access denied");  
//     }

// using System;

// var temp = double.Parse(Console.ReadLine());
// var vbr = double.Parse(Console.ReadLine());

// var status = GetEngineStatus(temp, vbr);
// Console.WriteLine(status);

// string GetEngineStatus(double temp, double vbr)
// {
//     if (temp>= 70 && vbr >=11)
//     {
//         return "Аварийное состояние";
//     }
//     else if (temp>= 70 && vbr <11)
//     {
//         return "Повышенная температура";
//     }
//     else if (temp < 70 && vbr >= 11)
//     {
//         return "Повышенная вибрация";
//     }
//     else //(temp < 70 && vbr <11)
//     {
//         return "Исправное состояние";
//     }   
// }

// проверка изменений

// using System;
// using System.Linq;

// var nums = Console.ReadLine()
//     .Split(" ")
//     .Select(x => int.Parse(x.Trim()))
//     .ToList();

// var result = nums
//     .Where(x => x % 2 != 0)   // берём только нечётные
//     .ToList();

// Console.WriteLine(string.Join(" ", result));  

// using System;
// using System.Linq;

// var nums = Console.ReadLine()
//     .Split(" ")
//     .Select(x => int.Parse(x.Trim()))
//     .ToList();

// string ToWord(int n)
// {
//     switch (n)
//     {
//         case 1: return "One";
//         case 2: return "Two";
//         case 3: return "Three";
//         case 4: return "Four";
//         case 5: return "Five";
//         default: return "";
//     }
// }

// var words = nums.Select(ToWord);
// Console.WriteLine(string.Join(" ", words));
    

// using System;
// using System.Linq;

// var nums = Console.ReadLine()
//     .Split(" ")
//     .Select(x => int.Parse(x.Trim()))
//     .ToList();

// int sum = nums.Sum();
// int product = 1;

// foreach (var n in nums)
// {
//     product *= n;
// }

// Console.WriteLine($"{sum} {product}");

// using System;

// public class MainClass
// {
//     public static void Main()
//     {
//         Console.WriteLine(DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", null).ToString("yyyy\\/MM\\/dd HH-mm-ss"));
//     }
// }

// 

// using System;

// class Program
// {
//     static void Main()
//     {
//         // Читаем строку чисел, например: 1 2 3 4 5
//         string input = Console.ReadLine();

//         string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//         int sum = 0;

//         foreach (string part in parts)
//         {
//             int number = int.Parse(part);
//             sum += number;
//         }

//         Console.WriteLine(sum);
//     }
// }


// using System;

// class Program
// {
//     static void Main()
//     {
//         // Читаем два массива строками
//         string line1 = Console.ReadLine();
//         string line2 = Console.ReadLine();

//         int[] a = Array.ConvertAll(
//             line1.Split(' ', StringSplitOptions.RemoveEmptyEntries),
//             int.Parse
//         );
//         int[] b = Array.ConvertAll(
//             line2.Split(' ', StringSplitOptions.RemoveEmptyEntries),
//             int.Parse
//         );

//         int maxLen = Math.Max(a.Length, b.Length);
//         int[] result = new int[maxLen];

//         for (int i = 0; i < maxLen; i++)
//         {
//             int x = i < a.Length ? a[i] : 0;
//             int y = i < b.Length ? b[i] : 0;
//             result[i] = x + y;
//         }

//         Console.WriteLine(string.Join(" ", result));
//     }
// }

// using System;

// enum SomeEnum
// {
//     Abcde,
//     Fghij,
//     Klmno,
//     Pqrst,
//     Uvwxy
// }

// class Program
// {
//     static void Main()
//     {
//         int n = int.Parse(Console.ReadLine()); // число от 0 до 4

//         string result = "";

//         foreach (SomeEnum value in Enum.GetValues(typeof(SomeEnum)))
//         {
//             string name = value.ToString(); // "Abcde", "Fghij" и т.д.
//             result += name[n];              // берём символ с позиции n
//         }

//         Console.WriteLine(result);
//     }
// }
//test commit
