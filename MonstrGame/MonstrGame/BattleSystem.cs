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
                int damage = rnd.Next(10, 21);

                int crit = rnd.Next(0, 100);
                //monster.Health =
                TakeDamagePlayer(damage, crit);
                //int damage = player.damage;//rnd.Next(10, 21);

                //int crit = player.crit;//rnd.Next(0, 100);

            }
         else if (numberMenu == 2)
            {
                int miss = rnd.Next(0, 100);
                int crit = rnd.Next(0, 100);
                int damageHigh = rnd.Next(20, 36);
                //monster.Health =
                TakeDamagePlayerHigh(damageHigh, crit, miss);
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
                int damage = rnd.Next(12, 23);
                int critMonstr = rnd.Next(0, 100);
                int evasion = rnd.Next(0, 100);
                //player.Health =
                TakeDamageMonster(damage, critMonstr,  evasion);
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

    internal  void TakeDamagePlayer(int damage, int crit)
    {
                 if(crit<5)
                {
                    damage *= 2;
                    monster.TakeDamage(damage);
                //  MinusNull(monster.Health);
            //     if (monster.Health < 0)
            // {
            //     monster.Health = 0;
            // }
                    Console.WriteLine($"\nКритический удар! Ты нанес монстру {damage} урона. У монстра осталось {monster.Health} здоровья.");
                }
                else
                {
                    monster.TakeDamage(damage);
                    //MinusNull(monster.Health);
            // if (monster.Health < 0)
            //     {
            //         monster.Health = 0;
            //     }
                    Console.WriteLine($"\nТы нанес монстру {damage} урона. У монстра осталось {monster.Health} здоровья.");
        }
       // return Health;

    }
    internal  void TakeDamageMonster(int damage, int critMonstr, int evasion)
    {
        if (critMonstr < 15)
                {
                    damage = damage*2;
                    Console.WriteLine($"\nУ монстра усиленный удар!");

                }
                if (evasion < 10)
                {
                    Console.WriteLine($"\nТы уклонился от атаки монстра!");

                }
                else
                {
                player.TakeDamage(damage);
                 //MinusNull(player.Health);
                Console.WriteLine($"\nМонстр атакует тебя и наносит {damage} урона. У тебя осталось {player.Health} здоровья.");
        }
    //return Health;

    }
    internal  void TakeDamagePlayerHigh(int damageHigh, int crit,int miss)
    {
          if (miss < 30)
                    Console.WriteLine($"\nТы промахнулся! Монстр не получил урона. У монстра осталось {monster.Health} здоровья.");
                else
                {
                if(crit<15)
                {
                    damageHigh *= 2;
                //Health -= damageHigh;
                monster.TakeDamage(damageHigh);
                //MinusNull(monster.Health);
                        Console.WriteLine($"\nКритический удар! Ты нанес монстру {damageHigh} урона. У монстра осталось {monster.Health} здоровья.");
                }
                else
                    {
                monster.TakeDamage(damageHigh);
               //MinusNull(monster.Health);
               Console.WriteLine($"\nТы нанес монстру {damageHigh} урона. У монстра осталось {monster.Health} здоровья.");


            }   //Console.WriteLine($"\nТы нанес монстру {damageHigh} урона. У монстра осталось {Health} здоровья.");
        }
     //   return Health;

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


    // static int MinusNull(int helf)
    // {
    //     if (helf < 0)
    //     {
    //         helf = 0;
    //     }
    //     return helf;
    // }

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

