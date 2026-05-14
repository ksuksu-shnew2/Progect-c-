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
        Console.WriteLine($"Баланс: {player.Balance}$ | Репутация: {player.Reputation}");
        

           Console.WriteLine("Доступные лоты:");
           var available = player.AvailableLots;
            for (int i = 0; i < available.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {available[i].Name} - {available[i].StartPrice}$");
            }
           Console.WriteLine();
           Console.WriteLine("Выбери лот (1/2/3/4/5/6/7/8/9) | Q - выход | 0 - выбрать последний лот");

           

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
            else if (key == ConsoleKey.D4 && player.AvailableLots.Count > 3)
            {
        
                    RunAuction(player.AvailableLots[3]);
                
            }
            else if (key == ConsoleKey.D5 && player.AvailableLots.Count > 4)
            {
        
                    RunAuction(player.AvailableLots[4]);
                
            }else if (key == ConsoleKey.D6 && player.AvailableLots.Count > 5)
            {
        
                    RunAuction(player.AvailableLots[5]);
                
            }else if (key == ConsoleKey.D7 && player.AvailableLots.Count > 6)
            {
        
                    RunAuction(player.AvailableLots[6]);
                
            }else if (key == ConsoleKey.D8 && player.AvailableLots.Count > 7)
            {
        
                    RunAuction(player.AvailableLots[7]);
                
            }else if (key == ConsoleKey.D9 && player.AvailableLots.Count > 8)
            {
        
                    RunAuction(player.AvailableLots[8]);
                
            }
            else if (key == ConsoleKey.D0 && player.AvailableLots.Count > 9)
            {
        
                    RunAuction(player.AvailableLots[9]);
                
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
        int earned = auction.Run(lot, player.ReputationBonus);
        if (earned == 0)
            {lot.ReducePrice();
            if (lot.Attempts >= lot.MaxAttempts)
                {
                Console.WriteLine($"Лот {lot.Name} снят с торгов после {lot.MaxAttempts} попыток!");
                lot.Withdraw();
                }
            else
                {
                Console.WriteLine($"Лот не продан, новая цена: {lot.StartPrice}$ | Попытка {lot.Attempts}/{lot.MaxAttempts}");
                }}
        else
        {
        player.AddMoney(earned);
        player.AddReputation(1);
        Console.WriteLine($"Аукцион завершен! Лот продан за {earned}. Победитель: {auction.Winner?.Name ?? "Увы, лот не продан"}");
        }
        
        Console.WriteLine($"Ваш новый баланс: {player.Balance}$");
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey(true);
   }
}
