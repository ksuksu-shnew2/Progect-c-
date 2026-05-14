namespace Aukcion;

public class Game
{
   Player player = new Player();
   Auction auction = new Auction();

    public void Start()1
   {
       Console.WriteLine("Добро пожаловать в аукцион!");
       var keyMap = new Dictionary<ConsoleKey, int>
            {
                { ConsoleKey.D1, 0 }, { ConsoleKey.D2, 1 }, { ConsoleKey.D3, 2 },
                { ConsoleKey.D4, 3 }, { ConsoleKey.D5, 4 }, { ConsoleKey.D6, 5 },
                { ConsoleKey.D7, 6 }, { ConsoleKey.D8, 7 }, { ConsoleKey.D9, 8 },
                { ConsoleKey.D0, 9 }
            };

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
            

            if (keyMap.TryGetValue(key, out int index) && index < available.Count)
                RunAuction(available[index]);
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
                lot.Sell(0);
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
