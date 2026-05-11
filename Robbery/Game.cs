namespace Robbery;

public class Game
{
    public Player player = new Player(20, 10);
    public HeistPlan plan = new HeistPlan();
    public List<HeistStage> stages = new List<HeistStage>();
    public int width = 40;
    public int height = 20;
    public string message = "";
    public bool planningPhase = true;
    public int maxTicks = 100;
    public int ticks = 0;


    public void Start()
        {
            ShowPlanning();  // всегда начинаем с планирования
            RunHeist();      // потом сразу выполнение
        }

    void RunHeist()
    {
        SpawnStages();
        Draw();
        ticks = 0;
        while (true)
        {
            var key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.W || key == ConsoleKey.UpArrow) { player.Direction = Direction.Up; player.Move(width, height); }
            else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow) { player.Direction = Direction.Down; player.Move(width, height); }
            else if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow) { player.Direction = Direction.Left; player.Move(width, height); }
            else if (key == ConsoleKey.D || key == ConsoleKey.RightArrow) { player.Direction = Direction.Right; player.Move(width, height); }
            else if (key == ConsoleKey.F) CheckInteraction();
            
            Draw();
            
            if (stages.All(s => s.IsComplete))
            {
                Console.WriteLine("ОГРАБЛЕНИЕ УДАЛОСЬ!");
                return;
            }
            ticks++;
            if (ticks >= maxTicks)            {
                Console.WriteLine("ВЫ ПРОВАЛИЛИ ОГРАБЛЕНИЕ!");
                return;
        }
    }
}
    void ShowPlanning()
    {
        while (planningPhase)
        {
            Console.Clear();
            Console.WriteLine("=== ПЛАНИРОВАНИЕ ОГРАБЛЕНИЯ ===");
            Console.WriteLine($"Бюджет: {plan.Budget}$");
            Console.WriteLine();
            
            for (int i = 0; i < plan.Specialists.Count; i++)
            {
                var s = plan.Specialists[i];
                Console.WriteLine($"{i + 1}. {s.Name} | {s.Role} | Цена: {s.Price}$ | Навык: {s.Skill}/10 | {(s.IsHired ? "✓ Нанят" : "Свободен")}");
            }
            
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine("1/2/3 - нанять | S - начать ограбление");

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1) 
            { 
                bool ok = plan.HireSpecialist(0);
                message = ok ? $"{plan.Specialists[0].Name} нанят!" : "Недостаточно бюджета!";
            }
            else if (key == ConsoleKey.D2)
            {
                bool ok = plan.HireSpecialist(1);
                message = ok ? $"{plan.Specialists[1].Name} нанят!" : "Недостаточно бюджета!";
            }
            else if (key == ConsoleKey.D3)
            {
                bool ok = plan.HireSpecialist(2);
                message = ok ? $"{plan.Specialists[2].Name} нанят!" : "Недостаточно бюджета!";
            }
            else if (key == ConsoleKey.S)
            {
                planningPhase = false;
            }
        }
    }
    void SpawnStages()
    {
        stages = new List<HeistStage>();
        stages.Add(new HeistStage("Сигнализация", Role.Hacker, Random.Shared.Next(2, width - 2), Random.Shared.Next(2, height - 2), 'S'));
        stages.Add(new HeistStage("Сейф", Role.Cracker, Random.Shared.Next(2, width - 2), Random.Shared.Next(2, height - 2), 'V'));
        stages.Add(new HeistStage("Побег", Role.Driver, Random.Shared.Next(2, width - 2), Random.Shared.Next(2, height - 2), 'C'));
    }
    void CheckInteraction()
    {
        foreach (var stage in stages)
        {
            if (!stage.IsComplete && Math.Abs(player.Pos.X - stage.Pos.X) <= 1 && 
    Math.Abs(player.Pos.Y - stage.Pos.Y) <= 1)
            {
                bool success = stage.TryExecute(plan);
                message = success ? $"Успех! {stage.Name} завершён." : $"Провал на этапе: {stage.Name}!";
                return;
            }
        }
        message = "";
    }
    void Draw()
    {
        Console.Clear();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                        Console.Write("#");
                    
                else if (x == player.Pos.X && y == player.Pos.Y)
                        Console.Write("@");
                else                
                {
                    var stage = stages.FirstOrDefault(s => s.Pos.X == x && s.Pos.Y == y && !s.IsComplete);
                    if (stage != null)
                        Console.Write(stage.Symbol);
                    else
                        Console.Write(" ");
                }
                
            }
            Console.WriteLine();
        }
        Console.WriteLine(message);
        Console.WriteLine($"Ходов осталось: {maxTicks - ticks} | F - действие");
    }
}


