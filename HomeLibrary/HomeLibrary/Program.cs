using System.Threading.Tasks.Dataflow;

Console.WriteLine("Введите название книги: ");
string NameBooks = Console.ReadLine(); 
 Console.WriteLine("Введите автора книги:");
string AutorBooks = Console.ReadLine(); 
 Console.WriteLine("Введите год издания книги: ");
int Year = int.Parse(Console.ReadLine()); 
Console.WriteLine("Введите ISBN");
string ISBN = Console.ReadLine(); 

Console.WriteLine("\nНазвание книги: "+ NameBooks);
Console.WriteLine("Автор книги: "+ AutorBooks);
Console.WriteLine("Год издания: "+ Year);
Console.WriteLine("ISBN: "+ ISBN);

