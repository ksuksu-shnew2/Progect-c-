using System;
using System.Globalization;
//using static System.Globalization.CultureInfo;
namespace MonstrGame;


class Program
{
    //static string filePath = "tasks.txt";
    static void Main()
    {
        //int numberMenu;
        //int HealthAmountmonster = 100;
        //int Player.HealthAmountPlayer = 100;
        //int Player.countHealthAmount= 3;
        Console.Clear();
        Player Player = new();
        Monster Monster = new();
        BattleSystem battleSystem = new();
        battleSystem.StartBattle();
        
     //   Console.WriteLine($"\n\n\nТы встретил монстра!");

        //Random rnd = new();
        //intPlayer.HealthAmount= 10;


        // while (Player.HealthAmountPlayer > 0 && Monster.HealthAmountMonster > 0)
        // {
        //     Console.WriteLine($"\nТвой ход! Выбери действие.");
        //     Console.WriteLine($"\nИгрок HP: {Player.HealthAmountPlayer} / 100\nМонстр HP: {Monster.HealthAmountMonster} / 100\nЗелья здоровья: {Player.countHealthAmount}");
        //     if(Monster.HealthAmountMonster <= 30 && Monster.HealthAmountMonster > 0)
        //     {
        //         Console.WriteLine($"\nМонстр выглядит сильно раненым!");
        //     }
           // PrintMenu();
           // numberMenu = ReadInt();
        
        // if (numberMenu == 1)
        // {
        //         //int valueAtaka = Player.valueAtaka;//rnd.Next(10, 21);
               
        //         //int crit = Player.crit;//rnd.Next(0, 100);
        //         if(Player.crit<5)
        //         {
        //             Player.valueAtaka *= 2;
        //             Monster.HealthAmountMonster -= Player.valueAtaka;
        //             if (Monster.HealthAmountMonster < 0)
        //         {
        //             Monster.HealthAmountMonster = 0;
        //         }
        //             Console.WriteLine($"\nКритический удар! Ты нанес монстру {Player.valueAtaka} урона. У монстра осталось {Monster.HealthAmountMonster} здоровья.");
        //         }
        //         else
        //         {
        //             Monster.HealthAmountMonster -= Player.valueAtaka;
        //               if (Monster.HealthAmountMonster < 0)
        //         {
        //             Monster.HealthAmountMonster = 0;
        //         }
        //             Console.WriteLine($"\nТы нанес монстру {Player.valueAtaka} урона. У монстра осталось {Monster.HealthAmountMonster} здоровья.");
        //         }
        // }
        // else if (numberMenu == 2)
        //     {
        //         //int miss = rnd.Next(0, 100);
        //         if (Player.miss < 30)
        //             Console.WriteLine($"\nТы промахнулся! Монстр не получил урона. У монстра осталось {Monster.HealthAmountMonster} здоровья.");
        //         else
        //         {
        //             int valueAtakaHigh = rnd.Next(20, 36);
                    
        //         //int crit = rnd.Next(0, 100);
        //         if(Player.crit<15)
        //         {
        //             Player.valueAtakaHigh *= 2;
        //                 Monster.HealthAmountMonster -= Player.valueAtakaHigh;
        //                   if (Monster.HealthAmountMonster < 0)
        //         {
        //             Monster.HealthAmountMonster = 0;
        //         }
        //                 Console.WriteLine($"\nКритический удар! Ты нанес монстру {Player.valueAtakaHigh} урона. У монстра осталось {Monster.HealthAmountMonster} здоровья.");
        //         }
        //         else
        //             {
        //                 Monster.HealthAmountMonster -= Player.valueAtakaHigh;

        //         if (Monster.HealthAmountMonster < 0)
        //         {
        //             Monster.HealthAmountMonster = 0;
        //         }                Console.WriteLine($"\nТы нанес монстру {Player.valueAtakaHigh} урона. У монстра осталось {Monster.HealthAmountMonster} здоровья.");
        //         }

        //         }

        // }
        // else if (numberMenu == 3)
        // {
        //         if (Player.countHealthAmount<= 0)
        //         {
        //             Console.WriteLine($"\nУ тебя закончились зелья здоровья! Выбери другое действие.");
        //             continue;
        //         }
        //         else if (Player.HealthAmountPlayer == 100)
        //         {
        //             Console.WriteLine($"\nУ тебя полное здоровье! Выбери другое действие.");
        //             continue;
        //         }
        //         else
        //         {
        //             Player.HealthAmountPlayer += Player.HealthAmount;
        //             Player.countHealthAmount--;
        //             Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {Player.countHealthAmount}");
        //         }
                
        //         if (Player.HealthAmountPlayer > 100)
        //         {
        //             Player.HealthAmountPlayer = 100;
        //         }
        //         Console.WriteLine($"\nТы восстановил {Player.HealthAmount} здоровья. У тебя осталось {Player.HealthAmountPlayer} здоровья,а у монстра осталось {HealthAmountmonster} здоровья.");
        // }
        // else if (numberMenu == 0) 
        // {
        //     Console.WriteLine($"\nТы решил отступить. Игра окончена.");
        //     break;
        // }
        // else 
        // {
        //     Console.WriteLine($"\nНекорректный выбор. Попробуй снова.");
        //     continue;
        // }
        // if (Monster.HealthAmountMonster > 0)
        // {
        //         Monster.valueMonstr = rnd.Next(12, 23);
        //         Monster.critMonstr = rnd.Next(0, 100);
        //         Monster.evasion = rnd.Next(0, 100);
        //         if (Monster.critMonstr < 15)
        //         {
        //             Monster.valueMonstr = Monster.valueMonstr*2;
        //             Console.WriteLine($"\nУ монстра усиленный удар!");

        //         }
        //         if (Monster.evasion < 10)
        //         {
        //             Console.WriteLine($"\nТы уклонился от атаки монстра!");

        //         }
        //         else
        //         {
        //             Player.HealthAmountPlayer -= Monster.valueMonstr;
        //         if (Player.HealthAmountPlayer < 0)
        //         {
        //             Player.HealthAmountPlayer = 0;
        //         }
        //         Console.WriteLine($"\nМонстр атакует тебя и наносит {Monster.valueMonstr} урона. У тебя осталось {Player.HealthAmountPlayer} здоровья.");
        //         }
        // }

        // else
        // {
        //     Console.WriteLine($"\nПоздравляем! Ты победил монстра!");
        //     break;
        // }
        // if (Player.HealthAmountPlayer <= 0)
        // {
        //     Console.WriteLine($"\nТы был повержен монстром. Игра окончена.");
        //         break;
        // }

        }
   }




