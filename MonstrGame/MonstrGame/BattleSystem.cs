using static System.Globalization.CultureInfo;
namespace MonstrGame;
using System.Globalization;

public class BattleSystem
{
    Player player = new ();
    Monster monster = new();
    public Random rnd = new();

    public void StartBattle()
    {
       
        Console.WriteLine($"\n\n\nТы встретил монстра!");

        while (player.Health > 0 && monster.Health > 0)
        {
            Console.WriteLine($"\nТвой ход! Выбери действие.");
            Console.WriteLine($"\nИгрок HP: {player.Health} / 100\nМонстр HP: {monster.Health} / 100\nЗелья здоровья: {player.countHelf}");
            if(monster.Health <= 30 && monster.Health > 0)
            {
                Console.WriteLine($"\nМонстр выглядит сильно раненым!");
            }
            PrintMenu();
            int numberMenu = ReadInt();

            if (numberMenu == 1)

            {
                player.demage = rnd.Next(10, 21);

                int crit = rnd.Next(0, 100);
                monster.Health = AtacaPlayer(player.demage, crit, monster.Health);
                //int player.demage = player.player.demage;//rnd.Next(10, 21);

                //int crit = player.crit;//rnd.Next(0, 100);

            }
         else if (numberMenu == 2)
            {
                int miss = rnd.Next(0, 100);
                int crit = rnd.Next(0, 100);
                player.demageHigh = rnd.Next(20, 36);
                monster.Health = AtacaPlayerHigh(player.demageHigh, crit,miss, monster.Health);
                //int miss = rnd.Next(0, 100);
        }
        else if (numberMenu == 3)
        {
                //player.Health = Health(player.countHelf, monster.Health, player.Health, player.helf);
                player.Half();
                //player.Health = MinusNull(player.Health);
            
                //Console.WriteLine($"\nТы восстановил {player.helf} здоровья. У тебя осталось {player.Health} здоровья,а у монстра осталось {monster.Health} здоровья.");

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

           
            if (monster.Health > 0)
            {
                int valueMonstr = rnd.Next(12, 23);
                int critMonstr = rnd.Next(0, 100);
                int evasion = rnd.Next(0, 100);
                player.Health = AtacaMonster(valueMonstr, critMonstr, player.Health,evasion);
            }

        }
        if (monster.Health <= 0)
            {
                Console.WriteLine("\nПоздравляем! Ты победил монстра!");
        }
        else if (player.Health <= 0)
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

    internal static int AtacaPlayer(int demage, int crit, int Health)
    {
                 if(crit<5)
                {
                    demage *= 2;
                    Health -= demage;
                    Health = MinusNull(Health);
            //     if (monster.Health < 0)
            // {
            //     monster.Health = 0;
            // }
                    Console.WriteLine($"\nКритический удар! Ты нанес монстру {demage} урона. У монстра осталось {Health} здоровья.");
                }
                else
                {
                    Health -= demage;
                    Health = MinusNull(Health);
            // if (monster.Health < 0)
            //     {
            //         monster.Health = 0;
            //     }
                    Console.WriteLine($"\nТы нанес монстру {demage} урона. У монстра осталось {Health} здоровья.");
        }
        return Health;

    }
    internal static int AtacaMonster(int valueMonstr, int critMonstr, int Health, int evasion)
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
                Health -= valueMonstr;
                Health = MinusNull(Health);
                Console.WriteLine($"\nМонстр атакует тебя и наносит {valueMonstr} урона. У тебя осталось {Health} здоровья.");
        }
    return Health;

    }
    internal static int AtacaPlayerHigh(int demageHigh, int crit,int miss, int Health)
    {
          if (miss < 30)
                    Console.WriteLine($"\nТы промахнулся! Монстр не получил урона. У монстра осталось {Health} здоровья.");
                else
                {
                if(crit<15)
                {
                    demageHigh *= 2;
                Health -= demageHigh;
                Health =MinusNull(Health);
                        Console.WriteLine($"\nКритический удар! Ты нанес монстру {demageHigh} урона. У монстра осталось {Health} здоровья.");
                }
                else
                    {
                        Health -= demageHigh;
               Health = MinusNull(Health);
               Console.WriteLine($"\nТы нанес монстру {demageHigh} урона. У монстра осталось {Health} здоровья.");


            }   //Console.WriteLine($"\nТы нанес монстру {player.demageHigh} урона. У монстра осталось {Health} здоровья.");
        }
        return Health;

    }

    // internal static int Health(int countHelf, int Health,int Health,int helf)
    // {
    //        if (countHelf<= 0)
    //             {
    //                 Console.WriteLine($"\nУ тебя закончились зелья здоровья! Выбери другое действие.");
    //             }
    //             else if (Health == 100)
    //             {
    //                 Console.WriteLine($"\nУ тебя полное здоровье! Выбери другое действие.");
    //             }
    //             else
    //             {
    //                 Health += helf;
    //                 countHelf--;
    //                 Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {countHelf}");
    //             }
    //             Health = MinusNull(Health);
            
    //             Console.WriteLine($"\nТы восстановил {helf} здоровья. У тебя осталось {Health} здоровья,а у монстра осталось {Health} здоровья.");

    //             return Health;

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

