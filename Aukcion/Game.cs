namespace Aukcion;

public class Game
{
   Player player = new Player();
   Auction auction = new Auction();

    public void Start()
   {
       Console.WriteLine("Добро пожаловать в аукцион!");
       while (true)
       {
        Console.Clear();
        Console.WriteLine($"{player.Balance}");
        

           Console.WriteLine("Доступные лоты:");
           var available = player.AvailableLots;
            for (int i = 0; i < available.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {available[i].Name} - {available[i].StartPrice}$");
            }
           Console.WriteLine();
           Console.WriteLine("Выбери лот (1/2/3) | Q - выход");

           

           if (player.AvailableLots.Count == 0)
                {
                    Console.WriteLine($"Все лоты проданы! Итоговый баланс: {player.Balance}$");
                    return;
                }
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1) 
            { 
                if (player.AvailableLots.Count > 0)
                    RunAuction(player.AvailableLots[0]);
            }
            else if (key == ConsoleKey.D2 && player.AvailableLots.Count > 1)
            {
                RunAuction(player.AvailableLots[1]);
            }
            else if (key == ConsoleKey.D3 && player.AvailableLots.Count > 2)
            {
        
                    RunAuction(player.AvailableLots[2]);
                
            }
            else if (key == ConsoleKey.Q)
            {
                Console.WriteLine("Спасибо за игру!");
                return;
            }
            
       }

       
   } 
   void RunAuction(Lot lot)
   {
        Console.Clear();
        Console.WriteLine($"Вы выбрали лот: {lot.Name} с стартовой ценой {lot.StartPrice}$");
        Console.WriteLine("Начинаем аукцион...");
        int earned = auction.Run(lot);
        Console.WriteLine($"Аукцион завершен! Лот продан за {earned}$");
        //player.Balance -= earned;
        player.AddMoney(earned);
        Console.WriteLine($"Ваш новый баланс: {player.Balance}$");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey(true);
   }
}
