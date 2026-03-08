using System.Threading.Tasks.Dataflow;
using System;
using System.Runtime.Serialization.Formatters;
using System.Timers;
using System.ComponentModel;



using System.Collections.Generic;

// public class Book
// {
//     public string Title { get; set; }    // Название
//     public string Author { get; set; }   // Автор
//     public int Year { get; set; }        // Год
//     public string ISBN { get; set; }     // ISBN

//     public Book(string title, string author, int year, string isbn)
//     {
//         Title = title;
//         Author = author;
//         Year = year;
//         ISBN = isbn;
//     }

//     public override string ToString()
//     {
//         return $"{Title} — {Author}, {Year}, ISBN: {ISBN}";
//     }
// }

// public class Library
// {
//     private List<Book> books = new List<Book>();

//     // Добавление книги
//     public void AddBook(Book book)
//     {
//         if (book != null)
//             books.Add(book);
//     }

//     // Удаление книги по ISBN (без LINQ)
//     public bool RemoveBookByIsbn(string isbn)
//     {
//         if (string.IsNullOrWhiteSpace(isbn))
//             return false;

//         Book found = null;

//         foreach (Book b in books)
//         {
//             if (b.ISBN == isbn)
//             {
//                 found = b;
//                 break;
//             }
//         }

//         if (found != null)
//         {
//             books.Remove(found);
//             Console.WriteLine("Книга удалена: " + found.Title);
//             return true;
//         }
//         else
//         {
//             Console.WriteLine("Книга с таким ISBN не найдена");
//             return false;
//         }
//     }

//     // Поиск по частичному совпадению названия (без LINQ)
//     public List<Book> SearchByTitle(string titlePart)
//     {
//         List<Book> result = new List<Book>();

//         if (string.IsNullOrWhiteSpace(titlePart))
//             return result;

//         string part = titlePart.ToLower();

//         foreach (Book b in books)
//         {
//             if (b.Title != null &&
//                 b.Title.ToLower().Contains(part))
//             {
//                 result.Add(b);
//             }
//         }

//         return result;
//     }

//     // Поиск по частичному совпадению автора (без LINQ)
//     public List<Book> SearchByAuthor(string authorPart)
//     {
//         List<Book> result = new List<Book>();

//         if (string.IsNullOrWhiteSpace(authorPart))
//             return result;

//         string part = authorPart.ToLower();

//         foreach (Book b in books)
//         {
//             if (b.Author != null &&
//                 b.Author.ToLower().Contains(part))
//             {
//                 result.Add(b);
//             }
//         }

//         return result;
//     }

//     // Поиск по частичному совпадению ISBN (без LINQ)
//     public List<Book> SearchByIsbn(string isbnPart)
//     {
//         List<Book> result = new List<Book>();

//         if (string.IsNullOrWhiteSpace(isbnPart))
//             return result;

//         string part = isbnPart.ToLower();

//         foreach (Book b in books)
//         {
//             if (b.ISBN != null &&
//                 b.ISBN.ToLower().Contains(part))
//             {
//                 result.Add(b);
//             }
//         }

//         return result;
//     }

//     // Поиск по полному совпадению года (без LINQ, ты уже почти сделал)
//     public List<Book> SearchByYear(int year)
//     {
//         List<Book> result = new List<Book>();

//         foreach (Book b in books)
//         {
//             if (b.Year == year)
//             {
//                 result.Add(b);
//             }
//         }

//         return result;
//     }

//     // Проверка пустоты без LINQ (вместо Any)
//     public void PrintAll()
//     {
//         if (books.Count == 0)
//         {
//             Console.WriteLine("Библиотека пуста");
//             return;
//         }

//         foreach (Book book in books)
//             Console.WriteLine(book);
//     }
// }

// // Пример использования
// public class Program
// {
//     public static void Main()
//     {
//         var library = new Library();

//         library.AddBook(new Book("Война и мир", "Лев Толстой", 1869, "111-111"));
//         library.AddBook(new Book("Преступление и наказание", "Фёдор Достоевский", 1866, "222-222"));
//         library.AddBook(new Book("Мастер и Маргарита", "Михаил Булгаков", 1966, "333-333"));

//         Console.WriteLine("Все книги:");
//         library.PrintAll();

//         Console.WriteLine("\nПоиск по названию (часть 'ма'):");
//         foreach (var b in library.SearchByTitle("ма"))
//             Console.WriteLine(b);

//         Console.WriteLine("\nПоиск по автору (часть 'досто'):");
//         foreach (var b in library.SearchByAuthor("досто"))
//             Console.WriteLine(b);

//         Console.WriteLine("\nПоиск по ISBN (часть '33'):");
//         foreach (var b in library.SearchByIsbn("33"))
//             Console.WriteLine(b);

//         Console.WriteLine("\nПоиск по году (1866):");
//         foreach (var b in library.SearchByYear(1866))
//             Console.WriteLine(b);

//         Console.WriteLine("\nУдаление книги по ISBN 222-222");
//         library.RemoveBookByIsbn("222-222");

//         Console.WriteLine("\nВсе книги после удаления:");
//         library.PrintAll();
//     }
// }


using System;
using System.Collections.Generic;

public record Book
{
    public string Title { get; init; }       // Название
    public string Author { get; init; }      // Автор
    public int Year { get; init; }           // Год
    public string ISBN { get; init; }        // ISBN

    // Новые поля
    public string? Comment { get; set; }     // Мои комментарии о книге (может быть null)
    public bool IsRead { get; set; }         // Признак, что книга прочитана

    public Book(
        string title,
        string author,
        int year,
        string isbn,
        string? comment = null,
        bool isRead = false)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Author = author ?? throw new ArgumentNullException(nameof(author));
        ISBN = isbn ?? throw new ArgumentNullException(nameof(isbn));
        Year = year;
        Comment = comment;
        IsRead = isRead;
    }

    public override string ToString()
    {
        var status = IsRead ? "прочитана" : "не прочитана";
        var commentText = string.IsNullOrWhiteSpace(Comment) ? "без комментариев" : Comment;
        return $"{Title} — {Author}, {Year}, ISBN: {ISBN} ({status}, комментарий: {commentText})";
    }
}
public class Library
{
    private readonly List<Book> books = new List<Book>();

    public void AddBook(Book? book)
    {
        if (book is null)
        {
            Console.WriteLine("Нельзя добавить пустую книгу (null).");
            return;
        }

        books.Add(book);
    }

    public bool RemoveBookByIsbn(string? isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("ISBN не должен быть пустым.");
            return false;
        }

        Book? found = null;

        foreach (Book b in books)
        {
            // Безопасно: b.ISBN не null по нашему контракту конструктора,
            // но всё равно можно подстраховаться
            if (string.Equals(b.ISBN, isbn, StringComparison.OrdinalIgnoreCase))
            {
                found = b;
                break;
            }
        }

        if (found is not null)
        {
            books.Remove(found);
            Console.WriteLine("Книга удалена: " + found.Title);
            return true;
        }

        Console.WriteLine("Книга с таким ISBN не найдена");
        return false;
    }

    public List<Book> SearchByTitle(string? titlePart)
    {
        var result = new List<Book>();

        if (string.IsNullOrWhiteSpace(titlePart))
            return result;

        string part = titlePart.Trim().ToLowerInvariant();

        foreach (Book b in books)
        {
            if (!string.IsNullOrEmpty(b.Title) &&
                b.Title.ToLowerInvariant().Contains(part))
            {
                result.Add(b);
            }
        }

        return result;
    }

    public List<Book> SearchByAuthor(string? authorPart)
    {
        var result = new List<Book>();

        if (string.IsNullOrWhiteSpace(authorPart))
            return result;

        string part = authorPart.Trim().ToLowerInvariant();

        foreach (Book b in books)
        {
            if (!string.IsNullOrEmpty(b.Author) &&
                b.Author.ToLowerInvariant().Contains(part))
            {
                result.Add(b);
            }
        }

        return result;
    }

    public List<Book> SearchByIsbn(string? isbnPart)
    {
        var result = new List<Book>();

        if (string.IsNullOrWhiteSpace(isbnPart))
            return result;

        string part = isbnPart.Trim().ToLowerInvariant();

        foreach (Book b in books)
        {
            if (!string.IsNullOrEmpty(b.ISBN) &&
                b.ISBN.ToLowerInvariant().Contains(part))
            {
                result.Add(b);
            }
        }

        return result;
    }

    public List<Book> SearchByYear(int year)
    {
        var result = new List<Book>();

        foreach (Book b in books)
        {
            if (b.Year == year)
            {
                result.Add(b);
            }
        }

        return result;
    }

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
public class Program
{
    public static void Main()
    {
        var library = new Library();

        library.AddBook(new Book(
            "Война и мир",
            "Лев Толстой",
            1869,
            "111-111",
            comment: "Читал в школе, тяжело, но мощно",
            isRead: true));

        library.AddBook(new Book(
            "Преступление и наказание",
            "Фёдор Достоевский",
            1866,
            "222-222",
            comment: "В планах прочитать",
            isRead: false));

        library.AddBook(new Book(
            "Мастер и Маргарита",
            "Михаил Булгаков",
            1966,
            "333-333",
            comment: "Одна из любимых",
            isRead: true));

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
