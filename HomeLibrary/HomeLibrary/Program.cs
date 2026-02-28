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

//     Console.WriteLine("Введите значение данных: ");

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

// while (true)
// {
//     Console.WriteLine("\n1. Ищем данные");
//     Console.WriteLine("0. Выход\n");
//     Console.WriteLine("Ваш выбор: ");


//     String userInput = Console.ReadLine();

//     if(string.IsNullOrWhiteSpace(userInput)
//     ||!int.TryParse(userInput,out int inputChoice)
//     || inputChoice<0
//     || inputChoice>1)
//     {
//         Console.WriteLine("Неправильный ввод! Введите число от 0 до 1");
//         continue;
//     }
//     else if (inputChoice==0) {return;}
    

//         Console.WriteLine("Введите название книги которую ищем: ");
//         string NameBooksSearch = Console.ReadLine(); 
//         bool found = false;

//         for (int i = 0; i < matrix.GetLength(0); i++)
//             {
//                 if (matrix[i, 0] == NameBooksSearch)
//                 {
//         Console.WriteLine($"Нашли {NameBooksSearch} в строке {i}, колонка {0}");
//         found = true;
//         break; // если нужно найти только первое совпадение
//                 }
//             }

//             if (!found)
//             {
//                 Console.WriteLine("Значение не найдено в этой колонке");
//             }
//         Console.WriteLine("Введите имя автора книги которую ищем: ");
//         string AutorBooksSearch = Console.ReadLine(); 
//         bool found1 = false;

//         for (int i = 0; i < matrix.GetLength(0); i++)
//             {
//                 if (matrix[i, 1] == AutorBooksSearch)
//                 {
//         Console.WriteLine($"Нашли {AutorBooksSearch} в строке {i}, колонка {1}");
//         found1 = true;
//         break; // если нужно найти только первое совпадение
//                 }
//             }

//             if (!found1)
//             {
//                 Console.WriteLine("Значение не найдено в этой колонке");
//             }
//         Console.WriteLine("Введите год издания книги которую ищем: ");
//         string YearSearch = Console.ReadLine(); 
//         bool found2 = false;

//         for (int i = 0; i < matrix.GetLength(0); i++)
//             {
//                 if (matrix[i, 2] == YearSearch)
//                 {
//         Console.WriteLine($"Нашли {YearSearch} в строке {i}, колонка {2}");
//         found2 = true;
//         break; // если нужно найти только первое совпадение
//                 }
//             }

//             if (!found2)
//             {
//                 Console.WriteLine("Значение не найдено в этой колонке");
//             }
//         Console.WriteLine("Введите ISBN книги которую ищем: ");
//         string ISBNSearch = Console.ReadLine(); 
//         bool found3 = false;

//         for (int i = 0; i < matrix.GetLength(0); i++)
//             {
//                 if (matrix[i, 3] == ISBNSearch)
//                 {
//         Console.WriteLine($"Нашли {ISBNSearch} в строке {i}, колонка {3}");
//         found3 = true;
//         break; // если нужно найти только первое совпадение
//                 }
//             }

//             if (!found3)
//             {
//                 Console.WriteLine("Значение не найдено в этой колонке");
//             }
// }



using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }    // Название
    public string Author { get; set; }   // Автор
    public int Year { get; set; }        // Год
    public string ISBN { get; set; }     // ISBN

    public Book(string title, string author, int year, string isbn)
    {
        Title = title;
        Author = author;
        Year = year;
        ISBN = isbn;
    }

    public override string ToString()
    {
        return $"{Title} — {Author}, {Year}, ISBN: {ISBN}";
    }
}

public class Library
{
    private List<Book> books = new List<Book>();

    // Добавление книги
    public void AddBook(Book book)
    {
        if (book != null)
            books.Add(book);
    }

    // Удаление книги по ISBN (без LINQ)
    public bool RemoveBookByIsbn(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            return false;

        Book found = null;

        foreach (Book b in books)
        {
            if (b.ISBN == isbn)
            {
                found = b;
                break;
            }
        }

        if (found != null)
        {
            books.Remove(found);
            Console.WriteLine("Книга удалена: " + found.Title);
            return true;
        }
        else
        {
            Console.WriteLine("Книга с таким ISBN не найдена");
            return false;
        }
    }

    // Поиск по частичному совпадению названия (без LINQ)
    public List<Book> SearchByTitle(string titlePart)
    {
        List<Book> result = new List<Book>();

        if (string.IsNullOrWhiteSpace(titlePart))
            return result;

        string part = titlePart.ToLower();

        foreach (Book b in books)
        {
            if (b.Title != null &&
                b.Title.ToLower().Contains(part))
            {
                result.Add(b);
            }
        }

        return result;
    }

    // Поиск по частичному совпадению автора (без LINQ)
    public List<Book> SearchByAuthor(string authorPart)
    {
        List<Book> result = new List<Book>();

        if (string.IsNullOrWhiteSpace(authorPart))
            return result;

        string part = authorPart.ToLower();

        foreach (Book b in books)
        {
            if (b.Author != null &&
                b.Author.ToLower().Contains(part))
            {
                result.Add(b);
            }
        }

        return result;
    }

    // Поиск по частичному совпадению ISBN (без LINQ)
    public List<Book> SearchByIsbn(string isbnPart)
    {
        List<Book> result = new List<Book>();

        if (string.IsNullOrWhiteSpace(isbnPart))
            return result;

        string part = isbnPart.ToLower();

        foreach (Book b in books)
        {
            if (b.ISBN != null &&
                b.ISBN.ToLower().Contains(part))
            {
                result.Add(b);
            }
        }

        return result;
    }

    // Поиск по полному совпадению года (без LINQ, ты уже почти сделал)
    public List<Book> SearchByYear(int year)
    {
        List<Book> result = new List<Book>();

        foreach (Book b in books)
        {
            if (b.Year == year)
            {
                result.Add(b);
            }
        }

        return result;
    }

    // Проверка пустоты без LINQ (вместо Any)
    public void PrintAll()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста");
            return;
        }

        foreach (Book book in books)
            Console.WriteLine(book);
    }
}

// Пример использования
public class Program
{
    public static void Main()
    {
        var library = new Library();

        library.AddBook(new Book("Война и мир", "Лев Толстой", 1869, "111-111"));
        library.AddBook(new Book("Преступление и наказание", "Фёдор Достоевский", 1866, "222-222"));
        library.AddBook(new Book("Мастер и Маргарита", "Михаил Булгаков", 1966, "333-333"));

        Console.WriteLine("Все книги:");
        library.PrintAll();

        Console.WriteLine("\nПоиск по названию (часть 'ма'):");
        foreach (var b in library.SearchByTitle("ма"))
            Console.WriteLine(b);

        Console.WriteLine("\nПоиск по автору (часть 'досто'):");
        foreach (var b in library.SearchByAuthor("досто"))
            Console.WriteLine(b);

        Console.WriteLine("\nПоиск по ISBN (часть '33'):");
        foreach (var b in library.SearchByIsbn("33"))
            Console.WriteLine(b);

        Console.WriteLine("\nПоиск по году (1866):");
        foreach (var b in library.SearchByYear(1866))
            Console.WriteLine(b);

        Console.WriteLine("\nУдаление книги по ISBN 222-222");
        library.RemoveBookByIsbn("222-222");

        Console.WriteLine("\nВсе книги после удаления:");
        library.PrintAll();
    }
}