namespace Banda;

public class Game
{
   public Player player = new Player(20,10);
    public List<District> districts = new List<District>();
    public List<Gang> gangMembers = new List<Gang>();
    public Enemy enemy = new Enemy(); 
    int width = 40;
    int height = 20;
    int ticks = 0;
    int hireCost = 200;
    string message = "";

    public void Start()
    {
        SpawnDistricts();
        Draw();

        while (true)
        {
            bool moved = ReadInput();
            if (moved) player.Move(width, height);
            foreach (var member in gangMembers)            {
                member.Update(districts);
            }
            enemy.Update(districts);
            ticks++;
            
            
            if (ticks % 10 == 0)
            {
                CollectIncome();
            }

            Draw();
            
            if (districts.All(d => d.Owner == Owner.Player))
            {
                Console.WriteLine("ПОБЕДА!");
                return;
            }   
                if (districts.All(d => d.Owner == Owner.Enemy))
                {
                    Console.WriteLine("ПОРАЖЕНИЕ!");
                    return;
                }
            // если все районы Player → ПОБЕДА
            // если все районы Enemy → ПОРАЖЕНИЕ
        }
    }

    bool ReadInput()
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
        {
            player.Direction = Direction.Up;
            return true;
        }
        if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
        {
            player.Direction = Direction.Down;
            return true;
        }
        if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
        {
            player.Direction = Direction.Left;
            return true;
        }
        if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
        {
            player.Direction = Direction.Right;
            return true;
        }
        if (key == ConsoleKey.F)
        {
            CheckInteraction();
            return false;
        }
        if (key == ConsoleKey.H)
        {
            if (player.HireMember(hireCost))
            {
                gangMembers.Add(new Gang(player.Pos.X + 1, player.Pos.Y));
            }
            return false;
        }
        return false;
    }

    void CheckInteraction()
    {
        var district = districts.FirstOrDefault(d => Math.Abs(d.Pos.X - player.Pos.X) <= 1 && Math.Abs(d.Pos.Y - player.Pos.Y) <= 1);
        if (district != null)
            {
                bool success = district.TryCapture(player.Power, Owner.Player);
                if (success)
                    message = $"Район захвачен! Доход: {district.Income}/10 ходов";
                else
                    message = $"Недостаточно силы! Defense: {district.Defense} | Power: {player.Power}";
            }
            else
            {
                message = "Нет района рядом!";
            }
    }

    void CollectIncome()
    {
        foreach (var district in districts.Where(d => d.Owner == Owner.Player))
        {
           player.AddIncome(district.Income); 
        }
    }

    void SpawnDistricts()
    {
    
        while (districts.Count < 6)
        {
            int x = Random.Shared.Next(1, width - 1);
            int y = Random.Shared.Next(1, height - 1);


            if (x == player.Pos.X && y == player.Pos.Y) continue;
            if (districts.Any(d => d.Pos.X == x && d.Pos.Y == y)) continue;

            var district = new District(x, y);
        
            // первые два делаем вражескими
                if (districts.Count < 2)
                    district.Owner = Owner.Enemy;
                
            districts.Add(district);
        }
        
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

                    else if (districts.Any(d => d.Pos.X == x && d.Pos.Y == y))
                    {
                        var district = districts.First(d => d.Pos.X == x && d.Pos.Y == y);
                        Console.Write(district.Symbol);
                    }

                    else if (gangMembers.Any(g => g.Pos.X == x && g.Pos.Y == y))
                    {
                        Console.Write("G");
                    }
                    else
                        Console.Write(" ");
                }
            Console.WriteLine();
        }
        Console.WriteLine($"Money: {player.Money} | Power: {player.Power} | Gang Size: {player.GangSize} | F-захват H-нанять");
        Console.WriteLine(message);
    }
}
