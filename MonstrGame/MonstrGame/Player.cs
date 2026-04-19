namespace MonstrGame;

public class Player
{
    public int helfPlayer { get; set; }
    public int helf {get; set; }
    public int countHelf {get; set; }
   


    public Player()
    {
        
        helfPlayer = 100;
        helf = 10;
        countHelf = 3;
        // rnd = new Random();
        // valueAtaka = rnd.Next(10, 21);
        // miss = rnd.Next(0, 100);
        // valueAtakaHigh = rnd.Next(20, 36);
        // crit = rnd.Next(0, 100);


    }
    public void Half()
    {
        if (countHelf<= 0)
                {
                    Console.WriteLine($"\nУ тебя закончились зелья здоровья! Выбери другое действие.");
                }
                else if (helfPlayer == 100)
                {
                    Console.WriteLine($"\nУ тебя полное здоровье! Выбери другое действие.");
                }
                else
        {
            
            
            helfPlayer += helf;
            countHelf--;
            if (helfPlayer > 100)
            {
                helfPlayer = 100;
            }
            
        }
            Console.WriteLine($"\nТы использовал зелье здоровья. Осталось: {countHelf}");
            Console.WriteLine($"\nТы восстановил {helf} здоровья. У тебя осталось {helfPlayer} здоровья");
        }
        //helfPlayer = MinusNull(helfPlayer);
}

