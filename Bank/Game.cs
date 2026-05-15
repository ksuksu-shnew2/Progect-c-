namespace Bank;

public class Game
{
    public Bank bank = new Bank(); 

    public void Start()
    {
        Console.WriteLine("Добро пожаловать в Bank Game!");
        Console.WriteLine($"Bank Game- ваш банк с начальным капиталом {bank.Capital}.");
        
        
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Принять вклад");
            Console.WriteLine("2. Выдать кредит");
            Console.WriteLine("3. Инвестировать");
            Console.WriteLine("4. Следующий день");
            Console.WriteLine("5. Статус");
            Console.WriteLine("Q. Выйти");

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1) ShowDeposits();
            else if (key == ConsoleKey.D2) ShowLoans();
            else if (key == ConsoleKey.D3) ShowInvestments();
            else if (key == ConsoleKey.D4) NextDay();
            else if (key == ConsoleKey.D5) ShowStatus();
            else if (key == ConsoleKey.Q) return;

        
            if (bank.Capital >= 1000000)
            {
                Console.WriteLine("Поздравляем! Вы достигли целевого капитала.");
            }
        }
    }

    void ShowDeposits()
    {
        var options = new List<(string name, int amount, double rate, int days)>
            {
                ("Артём",  5000,  0.03,  10),
                ("Макс",   8000,  0.02,  20),
                ("Лена",   3000,  0.04,  7),
                ("Игорь",  15000, 0.01,  30),
                ("Катя",   6000,  0.035, 14)
            };
        Console.WriteLine("\n====ВКЛАДЫ:====");
        for (int i = 0; i < options.Count; i++)
    Console.WriteLine($"{i+1}. {options[i].name} — {options[i].amount}$ | {options[i].rate*100:F1}% в день | {options[i].days} дней");
        Console.WriteLine($"Капитал: {bank.Capital}");
        Console.WriteLine("Выбери (1-5) или B для возврата:");

        var key = Console.ReadKey(true).Key;
        var keyMap = new Dictionary<ConsoleKey, int>
            {
                { ConsoleKey.D1, 0 }, { ConsoleKey.D2, 1 }, { ConsoleKey.D3, 2 },
                { ConsoleKey.D4, 3 }, { ConsoleKey.D5, 4 }
            };
            
            if (keyMap.TryGetValue(key, out int index) && index < 5)
                {var (name, amount, rate, days) = options[index];
                bool ok = bank.AddDeposit(name, amount, rate, days);
                if (ok)
                    Console.WriteLine($"Вы приняли вклад от {name} на сумму {amount}$ с ставкой {rate} на {days} дней.");
                else
                    Console.WriteLine("Недостаточно капитала для принятия вклада.");}
            else if (key == ConsoleKey.B)
                return;
            
    }

    void ShowLoans() 
    { var options = new List<(string name, int amount, double rate, int days)>
            {
                ("Виктор", 10000, 0.08, 15),
                ("Саша",   5000,  0.10, 10),
                ("Денис",  20000, 0.06, 25),
                ("Оля",    7000,  0.09, 12),
                ("Рома",   3000,  0.12, 7)
            };
        Console.WriteLine("\n====КРЕДИТЫ:====");
        for (int i = 0; i < options.Count; i++)
    Console.WriteLine($"{i+1}. {options[i].name} — {options[i].amount}$ | {options[i].rate*100}% в день | {options[i].days} дней");
        Console.WriteLine($"Капитал: {bank.Capital}");
        Console.WriteLine("Выбери (1-5) или B для возврата:");

        var key = Console.ReadKey(true).Key;
        var keyMap = new Dictionary<ConsoleKey, int>
            {
                { ConsoleKey.D1, 0 }, { ConsoleKey.D2, 1 }, { ConsoleKey.D3, 2 },
                { ConsoleKey.D4, 3 }, { ConsoleKey.D5, 4 }
            };
            
            if (keyMap.TryGetValue(key, out int index) && index < 5)
                {var (name, amount, rate, days) = options[index];
                bool ok = bank.AddLoan(name, amount, rate, days);
                if (ok)
                    Console.WriteLine($"Вы выдали кредит {name} на сумму {amount}$ с ставкой {rate} на {days} дней.");
                else
                    Console.WriteLine("Недостаточно капитала для выдачи кредита.");}
            else if (key == ConsoleKey.B)
                return;
    }
    void ShowInvestments() 
    { 
        var options = new List<(string name, int amount, RiskLevel risk, int days)>
            {
                ("Золото",  5000,  RiskLevel.Low,  10),
                ("Недвижимость",   8000,  RiskLevel.Medium,  20),
                ("Стартап",   3000,  RiskLevel.High,  7),
                ("Акции",  15000, RiskLevel.Medium,  30),
                ("Криптовалюта",   6000,  RiskLevel.High, 14)
            };
        Console.WriteLine("\n====ИНВЕСТИЦИИ:====");
        for (int i = 0; i < options.Count; i++)
    Console.WriteLine($"{i+1}. {options[i].name} — {options[i].amount}$ | Риск: {options[i].risk} | {options[i].days} дней");
        Console.WriteLine($"Капитал: {bank.Capital}");
        Console.WriteLine("Выбери (1-5) или B для возврата:");    

        var key = Console.ReadKey(true).Key;
        var keyMap = new Dictionary<ConsoleKey, int>
            {
                { ConsoleKey.D1, 0 }, { ConsoleKey.D2, 1 }, { ConsoleKey.D3, 2 },
                { ConsoleKey.D4, 3 }, { ConsoleKey.D5, 4 }
            };
            
            if (keyMap.TryGetValue(key, out int index) && index < 5)
                {var (name, amount, risk, days) = options[index];
                bool ok = bank.AddInvestment(name, amount, risk, days);
                if (ok)
                    Console.WriteLine($"Вы сделали инвестицию в {name} на сумму {amount}$ с доходностью {risk} на {days} дней.");
                else
                    Console.WriteLine("Недостаточно капитала для сделки.");}
            else if (key == ConsoleKey.B)
                return;  
    }
    void NextDay() 
    { bank.NextDay(); 
    Console.WriteLine($"День {bank.Day}. Капитал: {bank.Capital}$"); Console.ReadKey(true); 
    }
    void ShowStatus() 
    {
        Console.WriteLine($"\n=== Статус банка ===");
        Console.WriteLine($"Капитал: {bank.Capital}$");
        Console.WriteLine($"Активные вклады: {bank.Deposits.Count(d => d.IsActive)}");
        Console.WriteLine($"Активные кредиты: {bank.Loans.Count(l => l.IsActive)}");
        Console.WriteLine($"Активные инвестиции: {bank.Investments.Count(i => i.IsActive)}");
        Console.ReadKey(true);
     }
}
