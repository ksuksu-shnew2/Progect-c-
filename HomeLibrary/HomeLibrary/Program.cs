using System.Threading.Tasks.Dataflow;
using System;
using System.Runtime.Serialization.Formatters;
using System.Timers;
using System.ComponentModel;

// Console.WriteLine("Введите название книги: ");
// string NameBooks = Console.ReadLine(); 
//  Console.WriteLine("Введите автора книги:");
// string AutorBooks = Console.ReadLine(); 
//  Console.WriteLine("Введите год издания книги: ");
// int Year = int.Parse(Console.ReadLine()); 
// Console.WriteLine("Введите ISBN");
// string ISBN = Console.ReadLine(); 

// Console.WriteLine("\nНазвание книги: "+ NameBooks);
// Console.WriteLine("Автор книги: "+ AutorBooks);
// Console.WriteLine("Год издания: "+ Year);
// Console.WriteLine("ISBN: "+ ISBN);

// Console.WriteLine("Введите значение: ");
// int value = int.Parse(Console.ReadLine()); 


// switch (value)
// {
// case 1:
// Console.WriteLine("Добавить книгу");
// break;
// case 2:
// Console.WriteLine("Показыть книгу");
// break;
// default:
// Console.WriteLine("Выйти");
// break;
// }

//Console.WriteLine("Введите значение: ");

// string[,] matrix = new string[5,4];

// for (int i = 0; i < matrix.GetLength(0); i++)

//         {
//             Console.WriteLine($"Книга №{i+1}");

//                 for (int j = 0; j < matrix.GetLength(1); j++)
//                     {
//                         string text;
//                         switch (j)
//                         {
//                         case 0:
//                         text = "Введите название книги";
//                         break;
//                         case 1:
//                         text = "Введите автора книги:";
//                         break;
//                         case 2:
//                         text = "Введите год издания книги: ";
//                         break;
//                         case 3:
//                         text = "Введите ISBN";
//                         break;
//                         default:
//                         text ="Выйти";
//                         break;
//                         }

//                         Console.Write($"{text}: ");

//                             matrix[i, j] = Console.ReadLine();                    

//                     }
//         }

//         Console.WriteLine("\nМассив получился такой:");

//         // Вывод
//         for (int i = 0; i < matrix.GetLength(0); i++)
//         {
//             for (int j = 0; j < matrix.GetLength(1); j++)
//             {
//                 Console.Write(matrix[i, j] + "\t");
//             }
//             Console.WriteLine();
//         }



while (true)
{
    Console.WriteLine("\n1. Ввести данные по книге");
    Console.WriteLine("0. Выход\n");
    Console.WriteLine("Ваш выбор: ");


    String userInput = Console.ReadLine();

    if(string.IsNullOrWhiteSpace(userInput)
    ||!int.TryParse(userInput,out int inputChoice)
    || inputChoice<0
    || inputChoice>1)
    {
        Console.WriteLine("Неправильный ввод! Введите число от 0 до 1");
        continue;
    }
    else if (inputChoice==0) {return;}
    
    Console.WriteLine("Вы молодец!");
    break;
    
}

 
           Console.WriteLine("Введите значение: ");

string[,] matrix = new string[5,4];

for (int i = 0; i < matrix.GetLength(0); i++)

        {
            Console.WriteLine($"Книга №{i+1}");

                for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        string text;
                        switch (j)
                        {
                        case 0:
                        text = "Введите название книги";
                        break;
                        case 1:
                        text = "Введите автора книги:";
                        break;
                        case 2:
                        text = "Введите год издания книги: ";
                        break;
                        case 3:
                        text = "Введите ISBN";
                        break;
                        default:
                        text ="Выйти";
                        break;
                        }

                        Console.Write($"{text}: ");
                      
                            matrix[i, j] = Console.ReadLine();                    

                    }
        }

        Console.WriteLine("\nМассив получился такой:");

        // Вывод
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Введите название книги которую ищем: ");
        string NameBooksSearch = Console.ReadLine(); 
        bool found = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] == NameBooksSearch)
                {
        Console.WriteLine($"Нашли {NameBooksSearch} в строке {i}, колонка {0}");
        found = true;
        break; // если нужно найти только первое совпадение
                }
            }

            if (!found)
            {
                Console.WriteLine("Значение не найдено в этой колонке");
            }
        Console.WriteLine("Введите имя автора книги которую ищем: ");
        string AutorBooksSearch = Console.ReadLine(); 
        bool found1 = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 1] == AutorBooksSearch)
                {
        Console.WriteLine($"Нашли {AutorBooksSearch} в строке {i}, колонка {1}");
        found1 = true;
        break; // если нужно найти только первое совпадение
                }
            }

            if (!found1)
            {
                Console.WriteLine("Значение не найдено в этой колонке");
            }
        Console.WriteLine("Введите год издания книги которую ищем: ");
        string YearSearch = Console.ReadLine(); 
        bool found2 = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 2] == YearSearch)
                {
        Console.WriteLine($"Нашли {YearSearch} в строке {i}, колонка {2}");
        found2 = true;
        break; // если нужно найти только первое совпадение
                }
            }

            if (!found2)
            {
                Console.WriteLine("Значение не найдено в этой колонке");
            }
        Console.WriteLine("Введите год издания книги которую ищем: ");
        string ISBNSearch = Console.ReadLine(); 
        bool found3 = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 3] == ISBNSearch)
                {
        Console.WriteLine($"Нашли {ISBNSearch} в строке {i}, колонка {3}");
        found3 = true;
        break; // если нужно найти только первое совпадение
                }
            }

            if (!found3)
            {
                Console.WriteLine("Значение не найдено в этой колонке");
            }
