namespace MonstrGame;

public class Player : Character
{
    ///public int HealthAmountPlayer { get; set; }
    public int HealthAmount {get; set; }
    public int countHealthAmount {get; set; }
   


    public Player()
    {
        
       
        HealthAmount = 10;
        countHealthAmount = 3;
       
    }
    public void Half()
    {
        if (countHealthAmount<= 0)
                {
                    Console.WriteLine($"\nУ тебя закончились зелья здоровья! Выбери другое действие.");
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
            
        }
            Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {countHealthAmount}");
            Console.WriteLine($"\nТы восстановил {HealthAmount} здоровья. У тебя осталось {Health} здоровья");
        }
        //HealthAmountPlayer = MinusNull(HealthAmountPlayer);
}

