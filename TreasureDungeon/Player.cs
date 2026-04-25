namespace TreasureDungeon;

public class Player : Character
{
    public int Gold { get; set; } = 0;

    public int helf { get; set; } = 10;
    //public int countHelf { get; set; } = 3;

     public Player()
    {
        Health = 100;
    }   
    public void AddGold(int gold)
    {
        Gold += gold;
        
        Console.WriteLine($"\nТы получил {gold} золота. У тебя теперь {Gold} золота");

    }

    public void Heal()
    {

        if (Health == 100)
                {
                    Console.WriteLine($"\nУ тебя полное здоровье! Выбери другое действие.");
                }
                else
        {
            
            
            Health += helf;
            //countHelf--;
            if (Health > 100)
            {
                Health = 100;
            }
            
        
            Console.WriteLine($"\nТы использовал зелье здоровья.");
            Console.WriteLine($"\nТы восстановил {helf} здоровья. У тебя осталось {Health} здоровья");
        }
        }
        //helfPlayer = MinusNull(helfPlayer);
}

