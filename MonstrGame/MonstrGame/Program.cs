using System;
using System.Globalization;
//using static System.Globalization.CultureInfo;
namespace MonstrGame;


class Program
{
    //static string filePath = "tasks.txt";
    static void Main()
    {
        int numberMenu;
        
        int helfmonster = 100;
        int helfPlayer = 100;
        int countHelf = 3;

        Console.Clear();
        Console.WriteLine($"\n\n\nТы встретил монстра!");

        Random rnd = new();
        
        
        
        int helf = 10;


        while (helfPlayer > 0 && helfmonster > 0)
        {
            Console.WriteLine($"\nТвой ход! Выбери действие.");
            Console.WriteLine($"\nИгрок HP: {helfPlayer} / 100\nМонстр HP: {helfmonster} / 100\nЗелья здоровья: {countHelf}");
            if(helfmonster <= 30 && helfmonster > 0)
            {
                Console.WriteLine($"\nМонстр выглядит сильно раненым!");
            }
            PrintMenu();
            numberMenu = ReadInt();
        
        if (numberMenu == 1)
        {
                int valueAtaka = rnd.Next(10, 21);
               
                int crit = rnd.Next(0, 100);
                if(crit<5)
                {
                    valueAtaka *= 2;
                    helfmonster -= valueAtaka;
                    if (helfmonster < 0)
                {
                    helfmonster = 0;
                }
                    Console.WriteLine($"\nКритический удар! Ты нанес монстру {valueAtaka} урона. У монстра осталось {helfmonster} здоровья.");
                }
                else
                {
                    helfmonster -= valueAtaka;
                      if (helfmonster < 0)
                {
                    helfmonster = 0;
                }
                    Console.WriteLine($"\nТы нанес монстру {valueAtaka} урона. У монстра осталось {helfmonster} здоровья.");
                }
        }
        else if (numberMenu == 2)
            {
                int miss = rnd.Next(0, 100);
                if (miss < 30)
                    Console.WriteLine($"\nТы промахнулся! Монстр не получил урона. У монстра осталось {helfmonster} здоровья.");
                else
                {
                    int valueAtakaHigh = rnd.Next(20, 36);
                    
                int crit = rnd.Next(0, 100);
                if(crit<15)
                {
                    valueAtakaHigh *= 2;
                        helfmonster -= valueAtakaHigh;
                          if (helfmonster < 0)
                {
                    helfmonster = 0;
                }
                        Console.WriteLine($"\nКритический удар! Ты нанес монстру {valueAtakaHigh} урона. У монстра осталось {helfmonster} здоровья.");
                }
                else
                    {
                        helfmonster -= valueAtakaHigh;

                if (helfmonster < 0)
                {
                    helfmonster = 0;
                }                Console.WriteLine($"\nТы нанес монстру {valueAtakaHigh} урона. У монстра осталось {helfmonster} здоровья.");
                }

                }

        }
        else if (numberMenu == 3)
        {
                if (countHelf <= 0)
                {
                    Console.WriteLine($"\nУ тебя закончились зелья здоровья! Выбери другое действие.");
                    continue;
                }
                else if (helfPlayer == 100)
                {
                    Console.WriteLine($"\nУ тебя полное здоровье! Выбери другое действие.");
                    continue;
                }
                else
                {
                    helfPlayer += helf;
                    countHelf--;
                    Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {countHelf}");
                }
                
                if (helfPlayer > 100)
                {
                    helfPlayer = 100;
                }
                Console.WriteLine($"\nТы восстановил {helf} здоровья. У тебя осталось {helfPlayer} здоровья,а у монстра осталось {helfmonster} здоровья.");
        }
        else if (numberMenu == 0) 
        {
            Console.WriteLine($"\nТы решил отступить. Игра окончена.");
            break;
        }
        else 
        {
            Console.WriteLine($"\nНекорректный выбор. Попробуй снова.");
            continue;
        }
        if (helfmonster > 0)
        {
                int valueMonstr = rnd.Next(12, 23);
                int critMonstr = rnd.Next(0, 100);
                int evasion = rnd.Next(0, 100);
                if (critMonstr < 15)
                {
                    valueMonstr = valueMonstr*2;
                    Console.WriteLine($"\nУ монстра усиленный удар!");

                }
                if (evasion < 10)
                {
                    Console.WriteLine($"\nТы уклонился от атаки монстра!");

                }
                else
                {
                    helfPlayer -= valueMonstr;
                if (helfPlayer < 0)
                {
                    helfPlayer = 0;
                }
                Console.WriteLine($"\nМонстр атакует тебя и наносит {valueMonstr} урона. У тебя осталось {helfPlayer} здоровья.");
                }
        }

        else
        {
            Console.WriteLine($"\nПоздравляем! Ты победил монстра!");
            break;
        }
        if (helfPlayer <= 0)
        {
            Console.WriteLine($"\nТы был повержен монстром. Игра окончена.");
                break;
        }

        }
   }



    internal static void PrintMenu()
    {
        Console.WriteLine("\n\n=== Возможные действия ===");
        Console.WriteLine($"1. Атаковать");
        Console.WriteLine($"2. Сильная атака");
        Console.WriteLine($"3. Лечение");
        Console.WriteLine("0. Выход\n");
        Console.WriteLine("Ваш выбор: ");

    }


    static int ReadInt()
    {
        int result = 0;
        while (!int.TryParse(Console.ReadLine()?.Replace(',', '.'),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out result))
        {
            Console.WriteLine("Вы ввели не число!");
        }
        return result;
    }

}



