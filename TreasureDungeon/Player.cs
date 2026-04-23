namespace TreasureDungeon;

public class Player : Charecter
{
    //public int Health {get; set; }= 100;
    public int Gold { get; set; } = 0;

    public int helf { get; set; } = 10;
    public int countHelf { get; set; } = 3;

        
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
            countHelf--;
            if (Health > 100)
            {
                Health = 100;
            }
            
        
            Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {countHelf}");
            Console.WriteLine($"\nТы восстановил {helf} здоровья. У тебя осталось {Health} здоровья");
        }
        }
        //helfPlayer = MinusNull(helfPlayer);
}

