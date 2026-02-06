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

class Program
{
    static void Main()
    {

      char a = '\u0041';
      char b = '\u0048';
      char d = '\u0065';
      char r = '\u006C';
      char g = '\u006F';


        // Выводим каждый символ и его Unicode-код
        Console.WriteLine($"Символ: '{a}' - (Unicode: \\u0041)");
        Console.WriteLine($"Символ: '{b}' - (Unicode: \\u0048)");
        Console.WriteLine($"Символ: '{d}' - (Unicode: \\u0065)");
        Console.WriteLine($"Символ: '{r}' - (Unicode: \\u006C)");
        Console.WriteLine($"Символ: '{g}' - (Unicode: \\u006F)");
    
        
    }
}