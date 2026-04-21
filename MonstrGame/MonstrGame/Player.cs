namespace MonstrGame;

public class Player : Character
{
    ///public int helfPlayer { get; set; }
    public int helf {get; set; }
    public int countHelf {get; set; }
   


    public Player()
    {
        
       
        helf = 10;
        countHelf = 3;
       
    }
    public void Half()
    {
        if (countHelf<= 0)
                {
                    Console.WriteLine($"\nУ тебя закончились зелья здоровья! Выбери другое действие.");
                }
                else if (Health == 100)
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
            
        }
            Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {countHelf}");
            Console.WriteLine($"\nТы восстановил {helf} здоровья. У тебя осталось {Health} здоровья");
        }
        //helfPlayer = MinusNull(helfPlayer);
}

