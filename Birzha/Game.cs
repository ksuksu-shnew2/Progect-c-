namespace Birzha;

public class Game
{
    public Market market = new Market();
    public Portfolio portfolio = new Portfolio();
    public string message = "";

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Day {market.Day}");
            Console.WriteLine($"Cash: ${portfolio.Cash:F2}");
            Console.WriteLine($"Total Value: ${portfolio.TotalValue:F2}");
            Console.WriteLine();
            Console.WriteLine("Stocks:");
            foreach (var stock in market.Stocks)
            {
                int quantity = portfolio.GetQuantity(stock);
                string holdingInfo = quantity > 0 ? $"(Holdings: {quantity})" : "";
                Console.WriteLine($"{stock.Name}: ${stock.Price:F2} {stock.Trend} {holdingInfo}");
            }
            Console.WriteLine();
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
                message = "";
            }
            Console.WriteLine("\nB-купить | S-продать | N-следующий день | Q-выйти");
            

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.B) ShowBuy();
            else if (key == ConsoleKey.S) ShowSell();
            else if (key == ConsoleKey.N) NextDay();
            else if (key == ConsoleKey.Q) return;
            
            if (portfolio.TotalValue >= 20000)
            {
                Console.WriteLine("Поздравляем! Вы достигли цели - удвоили свой капитал.");
                return;
            }
        }
    }
    public void ShowBuy()
    {
        Console.WriteLine("\nВыберите акцию для покупки:");
        for (int i = 0; i < market.Stocks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {market.Stocks[i].Name} - ${market.Stocks[i].Price:F2}");
        }
        Console.WriteLine("B-вернуться");
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.B) return;

        int index = key - ConsoleKey.D1;
        if (index >= 0 && index < market.Stocks.Count)
        {
            var stock = market.Stocks[index];
            Console.WriteLine($"Сколько акций {stock.Name} вы хотите купить?");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                if (portfolio.Buy(stock, quantity))
                {
                    message = $"Вы купили {quantity} акций {stock.Name}.";
                }
                else
                {
                    message = "Недостаточно наличных для покупки.";
                }
            }
            else
            {
                message = "Неверное количество.";
            }
        }
    }
    public void ShowSell()
    {
        Console.WriteLine("\nВыберите акцию для продажи:");
        var ownedStocks = portfolio.Holdings.Keys.ToList();
        for (int i = 0; i < ownedStocks.Count; i++)
        {
            var stock = ownedStocks[i];
            int quantity = portfolio.GetQuantity(stock);
            Console.WriteLine($"{i + 1}. {stock.Name} - ${stock.Price:F2} (Holdings: {quantity})");
        }
        Console.WriteLine("B-вернуться");
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.B) return;

        int index = key - ConsoleKey.D1;
        if (index >= 0 && index < ownedStocks.Count)
        {
            var stock = ownedStocks[index];
            Console.WriteLine($"Сколько акций {stock.Name} вы хотите продать?");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                if (portfolio.Sell(stock, quantity))
                {
                    message = $"Вы продали {quantity} акций {stock.Name}.";
                }
                else
                {
                    message = "Недостаточно акций для продажи.";
                }
            }
            else
            {
                message = "Неверное количество.";
            }
        }
    }
    void NextDay()
    {
        market.NextDay();
        message = $"День {market.Day} — цены обновлены.";
    }


}
