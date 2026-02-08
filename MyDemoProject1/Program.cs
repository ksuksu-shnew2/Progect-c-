// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// var varValue = 100;
// short shortValue;
//  sbyte sbyteValue;
// ushort ushortValue;
// long longValue;

// longValue = varValue;
// sbyteValue = (sbyte)varValue;
// ushortValue = (ushort)sbyteValue;
// shortValue = (short)ushortValue;

// Console.WriteLine(sbyteValue);
// Console.WriteLine(ushortValue);
// Console.WriteLine(shortValue);

// long longValue = 100;
// var varValue = 100.0;
// float floatValue;
// double doubleValue;
// decimal decimalValue;

// longValue = (long)varValue;
// floatValue = (float)varValue;
// doubleValue = varValue;
// decimalValue = (decimal)varValue;
// doubleValue = (double)decimalValue;
// decimalValue = longValue;

// Console.WriteLine(longValue);
// Console.WriteLine(decimalValue);
// Console.WriteLine(doubleValue);

// int millenniumDigit = 2;
// int centuryDigit = 0;
// int decadeDigit = 2;
// int yearDigit = 5;
// //int year = (yearDigit*yearDigit*yearDigit*yearDigit*millenniumDigit*millenniumDigit)-(millenniumDigit*yearDigit*millenniumDigit*yearDigit*yearDigit)+(yearDigit*yearDigit);
// int year = millenniumDigit*1000+centuryDigit*100+decadeDigit*10+yearDigit;

// Console.WriteLine(year);


// Исправить формулу вычисления нормальной массы тела (индекс Татоня)
// рост [см] — (100 + (рост [см] — 100) / 20)
//180-(100+(180-100)/20) 180-140=40

// const int OneHundred = 100;
// const int Twenty = 20;
// var height = 1.8;
// int heightMetr;
// heightMetr = ((OneHundred*height));
// Console.WriteLine(heightMetr);
// // float floatValue;
// // floatValue = (float)height;
// int normalWeight = (heightMetr - (OneHundred + (heightMetr - OneHundred) / Twenty));

// Console.WriteLine(normalWeight);



// char bigLetter = 'Я';
// char smallLetter = 'z';
// int value1 = (int)0x3A6;
// ushort value2 =(ushort)'\u0824';
// long value3 = (long)10574;
// int value4 = '\x25A3';
// Console.WriteLine(value4);
// Используя метод (экземплярный или статический)
// 1. Преобразовать переменную bigLetter в строчную букву, smallLetter в прописную
// 2. Объяснить почему нет ошибки при инициализации
// переменных value1, value2, value3, value4
// 3. Вывести на экран символ соответствующий значению этих переменных
// 4. Вывести на экран категории этих символов


// bigLetter   = char.ToLower(bigLetter); // 'a'
// smallLetter = char.ToUpper(smallLetter); // 'B'

// Console.WriteLine(bigLetter);
// Console.WriteLine(smallLetter);

// Console.WriteLine(value1); 
// Console.WriteLine(value2); 
// Console.WriteLine(value3); 
// Console.WriteLine(value4); 

// string first = "Меня";
// string second = "зовут";

// string third = Console.ReadLine();  // потом читаем строку без аргументов


// string res=  "\n" + first + "\n" + second + "\n" + third + "\n";
// Console.WriteLine(res);

// //string res= first + "\n" + second + "\n" + third;
// Console.WriteLine(first);
// Console.WriteLine(second);
// Console.WriteLine(third);

// string res2= $"\n{first}\n{second}\n{third}";
// Console.WriteLine(res2);

// string stringValue = $@"
// {first}
// {second}
// ksu";
// Console.WriteLine(stringValue);

//string third = Console.ReadLine("Ksu");

// Составьте из трёх строк одну строку таким образом,
// чтобы каждое слово было на новой строке.
// Используйте все варианты изученные нами на теоретическом уроке
// Сколько способов вы нашли?
 using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security;
using System.Threading.Channels;
// class Program
// {
//     static void Main()
//     {
//       int a = 4;
//       double b = 1.23;
//       string c = "Primer";
//       char d = 'A';
//       object e = 6;

//       Console.WriteLine("int :"+ a);
//       Console.WriteLine("double :"+ b);
//       Console.WriteLine("string :"+c);
//       Console.WriteLine("char :" +d);
//       Console.WriteLine("object :" +e);

//     }
// }

// class Program
// {
//     static void Main()
//     {
//       var a = 4;
//       var b = 1.23;
//       var c = "Primer";
//       var d = 'A';
//       var e = true;

//       Console.WriteLine("var int = "+ a +"; Type: " + a.GetType().Name);
//       Console.WriteLine("var double = "+ b +"; Type: " + b.GetType().Name);
//       Console.WriteLine("var string = " + c +"; Type: " + c.GetType().Name);
//       Console.WriteLine("var char = " + d +"; Type: " + d.GetType().Name);
//       Console.WriteLine("var bool = " + e +"; Type: " + e.GetType().Name);

//     }
// }

// class Program
// {
//     static void Main()
//     {
//       int a = 4;
//       double b = 1.23;
//       float c = 1.5F;
//       decimal d = 99.99M;
//       double e = -2.3;
//       int f = (int)b;
//       int j = (int)e;
//       int h = (int)d;
//       int k = (int)c;
//       double o = (double)a;

//       Console.WriteLine(b + "(" + b.GetType().Name + ")-> " + f + "(" + f.GetType().Name + ")");
//       Console.WriteLine(c + "(" + c.GetType().Name + ")-> " + k + "(" + k.GetType().Name + ")");
//       Console.WriteLine(d + "(" + d.GetType().Name + ")-> " + h + "(" + h.GetType().Name + ")");
//       Console.WriteLine(e + "(" + e.GetType().Name + ")-> " + j + "(" + j.GetType().Name + ")");
//       Console.WriteLine(a + "(" + a.GetType().Name + ")-> " + o + "(" + o.GetType().Name + ")");

//     }
// }

// class Program
// {
//     static void Main()
//     {
//       const int a = 4;
//       const double b = 1.23;
//       const string c = "Primer";
//       const char d = 'A';
//       const bool e = false;

//     //   a=5;
//     //   b=2.2;
//     //   c="Test";
//     //   d='V';
//     //   e=true;


//       Console.WriteLine("a: " + a);
//       Console.WriteLine("b: " + b);
//       Console.WriteLine("c: " + c);
//       Console.WriteLine("d: " + d);
//       Console.WriteLine("e: " + e);

//     }
// }

// class Program
// {
//     static void Main()
//     {


//         char a = '\n';
//         char b = '\t';
//         char c = '\\';
//         char d = '\'';
//         char e = '\"';
//         char f = '\0';

//         // string a = "Символ: '\n' - Новая строка";
//         // string b = "Символ: '\t' - Табуляция";
//         // string c = "Символ: '\\' - Обратная косая черта";
//         // string d = "Символ: '\'' - Одинарная кавычка";
//         // string e = "Символ: '\"' - Двойная кавычка";



//      Console.WriteLine($"Символ: '\n' (код {(int)a}) - Новая строка");
//       Console.WriteLine($"Символ: '\t' (код {(int)b})  - Табуляция");
//       Console.WriteLine($"Символ: '\\' (код {(int)c})  - Обратная косая черта");
//       Console.WriteLine($"Символ: '\'' (код {(int)d})  - Одинарная кавычка");
//       Console.WriteLine($"Символ: '\"' (код {(int)e})  - Двойная кавычка");
//       Console.WriteLine($"Символ: '\0' (код {(int)f})  - Нулевой символ"); 
//     }
// }

// class Program
// {
//     static void Main()
//     {


//         int a = 5;

//         {
//             int b= 10;
//             a=15;
//             //c=6;
//             Console.WriteLine("внешняя = "+a);
//             Console.WriteLine("внутреняя 1 = "+b);
//         }

//         {
//             int c= 8;
//             Console.WriteLine("внутреняя 2= "+c);
//             //b=6;
//         }

//         //c=30;
//         //b=20;


//     Console.WriteLine("внешняя = "+a);
//     }
// }


// class Program
// {
//     static void Main()
//     {
//       int a = 4;
//     //   double b = 1.23;
//     //   float c = 1.5F;
//       byte d = 1;
//       long e = 10000000000L;
//       short f = 55;

//       short r = d;
//       int j = f;
//       long h = a;
//       float k = a;
//       double o = e;

//       Console.WriteLine(d + "(" + d.GetType().Name + ")-> " + r + "(" + r.GetType().Name + ")");
//       Console.WriteLine(f + "(" + f.GetType().Name + ")-> " + j + "(" + j.GetType().Name + ")");
//       Console.WriteLine(a + "(" + a.GetType().Name + ")-> " + h + "(" + h.GetType().Name + ")");
//       Console.WriteLine(a + "(" + a.GetType().Name + ")-> " + k + "(" + k.GetType().Name + ")");
//       Console.WriteLine(e + "(" + e.GetType().Name + ")-> " + o + "(" + o.GetType().Name + ")");

//     }
// }

// class Program
// {
//     static void Main()
//     {

//        //long b = 12300000L;
//        float c = 1.5F;
//       decimal d = 100.289M;
//       long e = 10000000000L;
//       uint a = 1U;

//     //   short r = d;
//     //   int j = f;
//     //   long h = a;
//     //   float k = a;
//     //   double o = e;

//       //Console.WriteLine(b + "(" + b.GetType().Name + ")");
//       Console.WriteLine(c + ":" + c.GetType().Name);
//       Console.WriteLine(d + ":" + d.GetType().Name);
//       Console.WriteLine(e + ":" + e.GetType().Name);
//       Console.WriteLine(a + ":" + a.GetType().Name);

//     }
// }

// class Program
// {
//     static void Main()
//     {

//       string a= "Первый текст";
//       //string b= "Второй текст";
//       string c= "текст";

//       char a1 = a[0];
//       char a2 = a[a.Length - 1];
//       char a3 = a[a.Length/2];

//       char c1 = c[0];
//       char c2 = c[c.Length - 1];
//       char c3 = c[c.Length/2];

//       //Console.WriteLine(b + "(" + b.GetType().Name + ")");
//       Console.WriteLine(a + " Длина: " + a.Length+ " Символ: " + a1);
//       Console.WriteLine(a + " Длина: " + a.Length+ " Символ: " + a2);
//       Console.WriteLine(a + " Длина: " + a.Length+ " Символ: " + a3);
//       Console.WriteLine(c + " Длина: " + c.Length+ " Символ: " + c1);
//       Console.WriteLine(c + " Длина: " + c.Length+ " Символ: " + c2);
//       Console.WriteLine(c + " Длина: " + c.Length+ " Символ: " + c3);

//     }
// }

// 

// int a = 10;
// int b = 100;
// int c = 1000;
// Console.WriteLine(a < b && b > a);
// Console.WriteLine(c > a && a < c);
// //  b = 100000;
// //  a = 10000;
// Console.WriteLine(!(b > c) && !(c < a));

// bool result = FirstEqualsSecond(10, 10) | FirstGreaterSecond(3, 2) | FirstLessSecond(2, 3);
// bool FirstEqualsSecond(int x, int y) {
// if (x != y) { Console.WriteLine("X НЕ равно Y"); }
// else { Console.WriteLine("X равно Y"); }
// return x == y;
// }
// bool FirstGreaterSecond(int x, int y) {
// if (x > y) { Console.WriteLine("X больше Y"); }
// else { Console.WriteLine("X меньше или равно Y"); }
// return x > y;
// }
// bool FirstLessSecond(int x, int y) {
// if (x < y) { Console.WriteLine("X меньше Y"); }
// else { Console.WriteLine("X больше или равно Y"); }
// return x < y;
// }

// object someValue = 42;
// switch (someValue)
// {
// case int i when i == 10:
// Console.WriteLine($"someValue это целое число со значением: {i}");
// break;
// case int i when i > 20:
// Console.WriteLine($"someValue это целое число 4 со значением: {i}");
// break;
// case double i:
// Console.WriteLine($"someValue это вещественное число со значением: {i}");
// break;
// default:
// Console.WriteLine("Тип someValue не определён");
// break;
// }

// object someValue = 5;
// switch (someValue)
// {
// case int i when i > 10:
// case short j when j > 10:
// case long k when k > 10:
// Console.WriteLine($"someValue больше 10: {someValue}");
// break;
// }

// Random rnd = new();
// int value = rnd.Next(6, 15);
// switch (value)
// {
// case 6:
// Console.WriteLine($"карта - шестерка: значение {value}");
// break;
// case 7:
// Console.WriteLine($"карта - семерка: значение {value}");
// break;
// case 8:
// Console.WriteLine($"карта - восьмерка: значение {value}");
// break;
// case 9:
// Console.WriteLine($"карта - девятка: значение {value}");
// break;
// case 10:
// Console.WriteLine($"карта - десятка: значение {value}");
// break;
// case 11:
// Console.WriteLine($"карта - валет: значение {value}");
// break;
// case 12:
// Console.WriteLine($"карта - дама: значение {value}");
// break;
// case 13:
// Console.WriteLine($"карта - король: значение {value}");
// break;
// case 14:
// Console.WriteLine($"карта - туз: значение {value}");
// break;
// default:
// Console.WriteLine("Такой карты нет");
// break;
// }

// Random rnd = new();
// int value = rnd.Next(6, 15);
// switch (value)
// {
// case 6:
// case 7:
// case 8:
// case 9:
// case 10:
// Console.WriteLine($"карта - обычная: значение {value}");
// break;
// case 11:
// case 12:
// case 13:
// Console.WriteLine($"карта - фигура: значение {value}");
// break;
// case 14:
// Console.WriteLine($"карта - туз: значение {value}");
// break;
// default:
// Console.WriteLine("Такой карты нет");
// break;
// }

// PrintTheType("Ы");
// PrintTheType(2.0F);
// PrintTheType(10.2M);
// PrintTheType(11L);

// static void PrintTheType(object value)
// {
// switch (value)
//   {
//     case string i:
//     Console.WriteLine($"value это string со значением: {i}");
//     break;
//     case float i:
//     Console.WriteLine($"value это float со значением: {i}");
//     break;
//     case decimal i:
//     Console.WriteLine($"value это decimal со значением: {i}");
//     break;
//     case long i:
//     Console.WriteLine($"value это long со значением: {i}");
//     break;
//   }
// }

// Random rnd = new();
// int value = rnd.Next(6, 15);
// Console.WriteLine(value);
// string carta = value switch
// {
//  6 => "шестерка",
//  7 => "семерка",
//  8 => "восьмерка",
//  9 => "девятка",
//  10 => "десятка",
//  11 => "валет",
//  12 => "дама",
//  13 => "король",
//  14 => "туз",
//   _ => "Неизвестная карта",
// };
// Console.WriteLine(carta);

// class Program
// {
//     static void Main()
//     {
//         bool a=true;
//         Console.WriteLine(a);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         int firstNumber = 15;
//         int secondNumber = 10;

//         bool a;
//         a = firstNumber == secondNumber;
//         Console.WriteLine(firstNumber +" == " + secondNumber + ": "+ a);
//         a = firstNumber != secondNumber;
//         Console.WriteLine(firstNumber +" != " + secondNumber + ": "+ a);
//         a = firstNumber >= secondNumber;
//         Console.WriteLine(firstNumber +" >= " + secondNumber + ": "+ a);
//         a = firstNumber <= secondNumber;
//         Console.WriteLine(firstNumber +" <= " + secondNumber + ": "+ a);
//         a = firstNumber < secondNumber;
//         Console.WriteLine(firstNumber +" < " + secondNumber + ": "+ a);
//         a = firstNumber > secondNumber;
//         Console.WriteLine(firstNumber +" > " + secondNumber + ": "+ a);


//     }
// }


// class Program
// {
//     static void Main()
//     {
//         bool originalValue = true;
//         originalValue=!(originalValue);
//         Console.WriteLine(originalValue);

//         // Ваш код здесь
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // **Описание**: Создайте программу, которая использует тернарный оператор (?:) для выбора максимального значения из двух чисел и выводит результат.
//         //
//         // **Входные данные**: Два целых числа (заданы в коде как переменные)
//         //
//         // **Выходные данные**: Максимальное значение из двух чисел
//         //
//         // **Ограничения**: Используйте только тернарный оператор (?:) для выбора значения
//         //
//         // **Примеры**:
//         // Числа: 8 и 12
//         // Максимальное значение: 12
//         //
//         // Числа: 15 и 9
//         // Максимальное значение: 15

//         int firstNumber = 8;
//         int secondNumber = 12;
//         int res;

//         res = firstNumber>secondNumber?firstNumber:secondNumber;
//         Console.WriteLine(res);


//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // **Описание**: Создайте программу, которая использует бинарные логические операции (&, |, ^) для работы с двумя булевыми значениями и выводит результаты всех операций.
//         // **Входные данные**: Два булевых значения (заданы в коде как переменные)
//         // **Выходные данные**: Результаты логических операций AND (&), OR (|) и XOR (^)
//         // **Ограничения**: Используйте только бинарные логические операторы (&, |, ^)
        
//         bool a = true;
//         bool b = false;

//         bool result;

//         result = a&b;
//         Console.WriteLine("Результат AND (&):" + result);
//         result = a|b;
//         Console.WriteLine("Результат OR (|):" + result);
//         result = a^b;
//         Console.WriteLine("Результат XOR (^):" + result);

//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // **Описание**: Создайте программу, которая использует условные операторы (&& и ||) для проверки двух булевых условий и демонстрирует сокращённое вычисление.
//         // **Входные данные**: Два булевых значения (заданы в коде как переменные)
//         // **Выходные данные**: Результаты логических операций && и || с демонстрацией сокращённого вычисления
//         // **Ограничения**: Используйте только условные операторы && и ||
        
//         bool a = true;
//         bool b = false;

//         bool result;

//         result = a&&b;
//         Console.WriteLine("Результат (&&):" + result);
//         result = a||b;
//         Console.WriteLine("Результат (||):" + result);
//     }
// }


// int dayNumber = 3;
// switch (dayNumber)
// {
// case 1:
// Console.WriteLine("Понедельник");
// break;
// case 2:
// Console.WriteLine("Вторник");
// break;
// case 3:
// Console.WriteLine("Среда");
// break;
// case 4:
// Console.WriteLine("Четверг");
// break;
// case 5:
// Console.WriteLine("Пятница");
// break;
// case 6:
// Console.WriteLine("Суббота");
// break;
// case 7:
// Console.WriteLine($"Воскресенье");
// break;
// default:
// Console.WriteLine("Неизвестный день");
// break;
// }

// class Program
// {
//     static void Main()
//     {
//         int number = 8;
//         int res;
//         res=number%2;
//       if(res==0)
//       {
//       Console.WriteLine("Число четное");
//       }
      
//       else
//       {
//        Console.WriteLine("Число нечетное"); 
//       }
    
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         object value = 42.4;

        
// switch (value)
//   {
//     case int i:
//     Console.WriteLine($"Это целое число: {i}");
//     break;
//     case string i:
//     Console.WriteLine($"Это строка: {i}");
//     break;
//     case decimal i:
//     Console.WriteLine($"Это decimal: {i}");
//     break;
//     default:
//     Console.WriteLine("Неизвестный тип"); 
//     break;
//   }
      
//     }
// }

class Program
{
    static void Main()
    {
        // **Описание**: Создайте программу, которая использует оператор if-else-if для классификации числа по диапазонам и выводит соответствующую категорию.
        // **Входные данные**: Целое число (задано в коде как переменная)
        // **Выходные данные**: Сообщение о категории числа
        // **Ограничения**: Используйте только конструкцию if-else-if с операторами сравнения

        int number = 125;

        if (number <= 50)
       {
       Console.WriteLine("Малое число");
       }
       else if ((number>50) & (number<100)) 
       {
       Console.WriteLine("Среднее число");
       }
       else 
       {
       Console.WriteLine("Большое число");
       }
        
    }
}