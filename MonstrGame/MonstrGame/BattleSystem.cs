using static System.Globalization.CultureInfo;
namespace MonstrGame;
using System.Globalization;

public class BattleSystem
{
    Player Player = new();
    Monster Monster = new();
    public Random rnd = new();

    public void StartBattle()
    {
       
        Console.WriteLine($"\n\n\nТы встретил монстра!");

        while (Player.helfPlayer > 0 && Monster.helfMonster > 0)
        {
            Console.WriteLine($"\nТвой ход! Выбери действие.");
            Console.WriteLine($"\nИгрок HP: {Player.helfPlayer} / 100\nМонстр HP: {Monster.helfMonster} / 100\nЗелья здоровья: {Player.countHelf}");
            if(Monster.helfMonster <= 30 && Monster.helfMonster > 0)
            {
                Console.WriteLine($"\nМонстр выглядит сильно раненым!");
            }
            PrintMenu();
            int numberMenu = ReadInt();

            if (numberMenu == 1)

            {
                int valueAtaka = rnd.Next(10, 21);

                int crit = rnd.Next(0, 100);
                Monster.helfMonster = AtacaPlayer(valueAtaka, crit, Monster.helfMonster);
                //int valueAtaka = Player.valueAtaka;//rnd.Next(10, 21);

                //int crit = Player.crit;//rnd.Next(0, 100);

            }
         else if (numberMenu == 2)
            {
                int miss = rnd.Next(0, 100);
                int crit = rnd.Next(0, 100);
                int valueAtakaHigh = rnd.Next(20, 36);
                Monster.helfMonster = AtacaPlayerHigh(valueAtakaHigh, crit,miss, Monster.helfMonster);
                //int miss = rnd.Next(0, 100);
        }
        else if (numberMenu == 3)
        {
                //Player.helfPlayer = HelfPlayer(Player.countHelf, Monster.helfMonster, Player.helfPlayer, Player.helf);
                Player.Half();
                //Player.helfPlayer = MinusNull(Player.helfPlayer);
            
                //Console.WriteLine($"\nТы восстановил {Player.helf} здоровья. У тебя осталось {Player.helfPlayer} здоровья,а у монстра осталось {Monster.helfMonster} здоровья.");

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

           
            if (Monster.helfMonster > 0)
            {
                int valueMonstr = rnd.Next(12, 23);
                int critMonstr = rnd.Next(0, 100);
                int evasion = rnd.Next(0, 100);
                Player.helfPlayer = AtacaMonster(valueMonstr, critMonstr, Player.helfPlayer,Monster.helfMonster,evasion);
            }

        // else
        // {
        //     Console.WriteLine($"\nПоздравляем! Ты победил монстра!");
        //     break;
        // }
        }
        if (Monster.helfMonster <= 0)
            {
                Console.WriteLine("\nПоздравляем! Ты победил монстра!");
        }
        else if (Player.helfPlayer <= 0)
        {
            Console.WriteLine($"\nТы был повержен монстром. Игра окончена.");
        }
    }

                //int miss = rnd.Next(0, 100);


    internal static void PrintMenu()
    {
        Console.WriteLine("\n\n=== Возможные действия ===");
        Console.WriteLine($"1. Атаковать");
        Console.WriteLine($"2. Сильная атака");
        Console.WriteLine($"3. Лечение");
        Console.WriteLine("0. Выход\n");
        Console.WriteLine("Ваш выбор: ");

    }

    internal static int AtacaPlayer(int valueAtaka, int crit, int helfMonster)
    {
                 if(crit<5)
                {
                    valueAtaka *= 2;
                    helfMonster -= valueAtaka;
                    helfMonster = MinusNull(helfMonster);
            //     if (Monster.helfMonster < 0)
            // {
            //     Monster.helfMonster = 0;
            // }
                    Console.WriteLine($"\nКритический удар! Ты нанес монстру {valueAtaka} урона. У монстра осталось {helfMonster} здоровья.");
                }
                else
                {
                    helfMonster -= valueAtaka;
                    helfMonster = MinusNull(helfMonster);
            // if (Monster.helfMonster < 0)
            //     {
            //         Monster.helfMonster = 0;
            //     }
                    Console.WriteLine($"\nТы нанес монстру {valueAtaka} урона. У монстра осталось {helfMonster} здоровья.");
        }
        return helfMonster;

    }
     internal static int AtacaMonster(int valueMonstr, int critMonstr, int helfPlayer, int helfMonster, int evasion)
    {
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
                helfPlayer = MinusNull(helfPlayer);
                Console.WriteLine($"\nМонстр атакует тебя и наносит {valueMonstr} урона. У тебя осталось {helfPlayer} здоровья.");
        }
    return helfPlayer;

    }
    internal static int AtacaPlayerHigh(int valueAtakaHigh, int crit,int miss, int helfMonster)
    {
          if (miss < 30)
                    Console.WriteLine($"\nТы промахнулся! Монстр не получил урона. У монстра осталось {helfMonster} здоровья.");
                else
                {
                if(crit<15)
                {
                    valueAtakaHigh *= 2;
                helfMonster -= valueAtakaHigh;
                helfMonster =MinusNull(helfMonster);
                        Console.WriteLine($"\nКритический удар! Ты нанес монстру {valueAtakaHigh} урона. У монстра осталось {helfMonster} здоровья.");
                }
                else
                    {
                        helfMonster -= valueAtakaHigh;
               helfMonster = MinusNull(helfMonster);
               Console.WriteLine($"\nТы нанес монстру {valueAtakaHigh} урона. У монстра осталось {helfMonster} здоровья.");


            }   //Console.WriteLine($"\nТы нанес монстру {valueAtakaHigh} урона. У монстра осталось {helfMonster} здоровья.");
        }
        return helfMonster;

    }

    // internal static int HelfPlayer(int countHelf, int helfMonster,int helfPlayer,int helf)
    // {
    //        if (countHelf<= 0)
    //             {
    //                 Console.WriteLine($"\nУ тебя закончились зелья здоровья! Выбери другое действие.");
    //             }
    //             else if (helfPlayer == 100)
    //             {
    //                 Console.WriteLine($"\nУ тебя полное здоровье! Выбери другое действие.");
    //             }
    //             else
    //             {
    //                 helfPlayer += helf;
    //                 countHelf--;
    //                 Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {countHelf}");
    //             }
    //             helfPlayer = MinusNull(helfPlayer);
            
    //             Console.WriteLine($"\nТы восстановил {helf} здоровья. У тебя осталось {helfPlayer} здоровья,а у монстра осталось {helfMonster} здоровья.");

    //             return helfPlayer;

    // }


    static int MinusNull(int helf)
    {
        if (helf < 0)
        {
            helf = 0;
        }
        return helf;
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

