using static System.Globalization.CultureInfo;
namespace TreasureDungeon;

using System.Globalization;

public class GameBattel
{
        private const int CritChance = 5;
        private const int MonsterCritChance = 15;
        private const int EvasionChance = 10;
        private const int MissChance = 30;
    //Player player = new ();
    

    //public Random rnd = new();

    public void StartBattle(Player player, Monster monster)
    {
        
        
        Console.WriteLine($"\n\n\nТы встретил монстра!");

        while (player.Health > 0 && monster.Health > 0)
        {
            // Console.WriteLine($"\nТвой ход! Выбери действие.");
            // Console.WriteLine($"\nИгрок HP: {player.Health} / 100\nМонстр HP: {monster.Health} / 100\nЗелья здоровья: {player.countHealthAmount}");
            if(monster.Health <= 10 && monster.Health > 0)
            {
                Console.WriteLine($"\nМонстр выглядит сильно раненым!");
            }
            PrintMenu();
            int numberMenu = ReadInt();

            if (numberMenu == 1)

            {
                int damage = RandomHelper.Rnd.Next(10, 21);

                int crit = RandomHelper.Rnd.Next(0, 100);
             
                TakeDamagePlayer(damage, crit, monster);
             
            }
         else if (numberMenu == 2)
            {
                int miss = RandomHelper.Rnd.Next(0, 100);
                int crit = RandomHelper.Rnd.Next(0, 100);
                int damageHigh = RandomHelper.Rnd.Next(20, 36);
                
                TakeDamagePlayerHigh(damageHigh, crit, miss, monster);
                
            }
        else if (numberMenu == 3)
            { 
                player.Healh();
                
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
                int damage = monster.Damage;
                int critMonstr = RandomHelper.Rnd.Next(0, 100);
                int evasion = RandomHelper.Rnd.Next(0, 100);
               
                TakeDamageMonster(damage, critMonstr,  evasion, player);
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



    internal static void PrintMenu()
    {
        Console.WriteLine("\n\n=== Возможные действия ===");
        Console.WriteLine($"1. Атаковать");
        Console.WriteLine($"2. Сильная атака");
        Console.WriteLine($"3. Лечение");
        Console.WriteLine("0. Выход\n");
        Console.WriteLine("Ваш выбор: ");

    }

    internal  void TakeDamagePlayer(int damage, int crit, Monster monster)
    {
                 if(crit<CritChance)
                {
                    damage *= 2;
                    monster.TakeDamage(damage);
              
                    Console.WriteLine($"\nКритический удар! Ты нанес монстру {damage} урона. У монстра осталось {monster.Health} здоровья.");
                }
                else
                {
                    monster.TakeDamage(damage);
          
                    Console.WriteLine($"\nТы нанес монстру {damage} урона. У монстра осталось {monster.Health} здоровья.");
        }
       

    }
    internal  void TakeDamageMonster(int damage, int critMonstr, int evasion, Player player)
    {
        
         if (evasion < EvasionChance)
                {
                    Console.WriteLine($"\nТы уклонился от атаки монстра!");
                    return;
                }
        if (critMonstr < MonsterCritChance)
                {
                    damage = damage*2;
                    Console.WriteLine($"\nУ монстра усиленный удар!");

                }
                player.TakeDamage(damage);
                 
                Console.WriteLine($"\nМонстр атакует тебя и наносит {damage} урона. У тебя осталось {player.Health} здоровья.");
        }
   

    
    internal  void TakeDamagePlayerHigh(int damageHigh, int crit,int miss,Monster monster)
    {
          if (miss < MissChance)
                    Console.WriteLine($"\nТы промахнулся! Монстр не получил урона. У монстра осталось {monster.Health} здоровья.");
                else
                {
                if(crit<CritChance)
                {
                    damageHigh *= 2;
               
                monster.TakeDamage(damageHigh);
               
                        Console.WriteLine($"\nКритический удар! Ты нанес монстру {damageHigh} урона. У монстра осталось {monster.Health} здоровья.");
                }
                else
                    {
                monster.TakeDamage(damageHigh);
               
               Console.WriteLine($"\nТы нанес монстру {damageHigh} урона. У монстра осталось {monster.Health} здоровья.");


            }   
        }
   

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

