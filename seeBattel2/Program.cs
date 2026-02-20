// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using System.Net;
using System.Text;
while(true)
{
    Console.WriteLine("\n1. Новая игра");
    Console.WriteLine("2. Загрузить игру");
    Console.WriteLine("3. Сохранить игру");
    Console.WriteLine("0. Выход\n");
    Console.WriteLine("Ваш выбор: ");


    String userInput = Console.ReadLine();

    if(string.IsNullOrWhiteSpace(userInput)
    ||!int.TryParse(userInput,out int inputChoice)
    || inputChoice<0
    || inputChoice>3)
    {
        Console.WriteLine("Неправильный ввод! Введите число от 0 до 3");
        continue;
    }
    Console.WriteLine("Вы молодец!");
    break;
}