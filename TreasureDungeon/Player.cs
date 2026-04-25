namespace TreasureDungeon;

public class Player : Character
{
    public int Gold { get; set; } = 0;

    public int HealthAmount { get; set; } = 10;
    public int countHealthAmount { get; set; } = 5;

     public Player()
    {
        Health = 100;
    }   
    public void AddGold(int gold)
    {
        Gold += gold;
        
        Console.WriteLine($"\nТы получил {gold} золота. У тебя теперь {Gold} золота");

    }

    public void UseHealthPotion()
    {
        if (countHealthAmount <= 0)
        {
            Console.WriteLine($"\nУ тебя нет зелья здоровья! Выбери другое действие.");
        }
         else if (Health <= 0)
        {
            Console.WriteLine($"\nТы уже мертв! Игра окончена.");
        }
        
        else if (Health == 100)
                {
                    Console.WriteLine($"\nУ тебя полное здоровье! Выбери другое действие.");
                }
                else
        {
            
            
            Health += HealthAmount;
            countHealthAmount--;
            if (Health > 100)
            {
                Health = 100;
            }
            
        
            Console.WriteLine($"\nТы использовал зелье здоровья.");
            Console.WriteLine($"\nТы восстановил {HealthAmount} здоровья. У тебя осталось {Health} здоровья");
        }
        }
        //HealthAmountPlayer = MinusNull(HealthAmountPlayer);
 }


