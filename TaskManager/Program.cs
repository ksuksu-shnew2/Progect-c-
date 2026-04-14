using System;
namespace TaskManager;

class Program
{

    static void Main()
    {
    
    }
    internal static void PrintMenu()
    {
        Console.WriteLine("\n=== Менеджер задач ===");
        Console.WriteLine("1. Показать все задачи");
        Console.WriteLine("2. Добавить задачу");
        Console.WriteLine("3. Удалить задачу");
        Console.WriteLine("0. Выход\n");
        Console.WriteLine("Ваш выбор: ");
    }
}


