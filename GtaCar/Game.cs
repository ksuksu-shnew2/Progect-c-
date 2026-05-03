namespace GtaCar;

public class Game
{
    public Player player = new Player(10, 4);
    public List<Car> cars = new List<Car>();
    public List<Police> polices = new List<Police>();
    public Garage garage;
    public int width = 40;
    public int height = 15;  
    public int score = 0;
    public int move = 0;

    public void Start()
    {
        SpawnAll();
        //Draw();

            while (true)
            {
            if (ReadInput())
            {
                player.Move(width, height);
            }
            foreach (var police in polices)
            {
                police.Move(player, width, height);
                if (player.Pos.X == police.Pos.X && player.Pos.Y == police.Pos.Y)
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    return;
                }
            }
            
            Draw();
            if (player.CarsDelivered >= 3)
            {
                Console.Clear();
                Console.WriteLine("ПОБЕДА!");
                Console.WriteLine($"Денег: {player.Money}");
                return;
            }
       }
    }

    bool ReadInput()
    {
        // if (Console.ReadKey(true).Key == ConsoleKey.Escape)
        //     return;

        ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.W || key == ConsoleKey.UpArrow) {player.Direction = Direction.Up; return true;}

            else if ((key == ConsoleKey.S || key == ConsoleKey.DownArrow)) {player.Direction = Direction.Down; return true;}

            else if ((key == ConsoleKey.A || key == ConsoleKey.LeftArrow)) {player.Direction = Direction.Left; return true;}

            else if ((key == ConsoleKey.D || key == ConsoleKey.RightArrow))  {player.Direction = Direction.Right; return true;}
            else if (key == ConsoleKey.E) { CheckInteraction(); return false; }
            else if (key == ConsoleKey.Escape) return false;
            else return false;
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
                {
                    if (player.HasCar) Console.Write("*");
                     else Console.Write("@");
                }
                else if (x == garage.Pos.X && y == garage.Pos.Y)
                    Console.Write("G");
                else if (cars.Any(t =>!t.IsStolen && t.Pos.X == x && t.Pos.Y == y))
                    Console.Write("C");
                else if (polices.Any(g => g.Pos.X == x && g.Pos.Y == y))
                    {var police = polices.First(g => g.Pos.X == x && g.Pos.Y == y);
                        Console.Write(police.IsChasing ? "!" : "P");}
                else
                    Console.Write(" "); 
            }
            Console.WriteLine();
           
        }
         Console.WriteLine($"Деньги: {player.Money} | Сдано: {player.CarsDelivered}/3 | E - угнать/сдать");
    }

    void SpawnAll()
    {
        int x = Random.Shared.Next(1, width - 1);
        int y = Random.Shared.Next(1, height - 1);
        // guards.Add(new HorizontalGuard(x, y));
        // guards.Add(new VerticalGuard(x, y));
        garage = new Garage(x, y);

        while (polices.Count < 2)
        {
            x = Random.Shared.Next(1, width - 1);
            y = Random.Shared.Next(1, height - 1);

            if (x == player.Pos.X && y == player.Pos.Y)
                continue;
            if (garage.Pos.X == x && garage.Pos.Y == y)
                continue;

            polices.Add(new Police(x, y));
        }

        while (cars.Count < 4)
        {
            x = Random.Shared.Next(1, width - 1);
            y = Random.Shared.Next(1, height - 1);

            if (x == player.Pos.X && y == player.Pos.Y)
                continue;
            if (cars.Any(c => c.Pos.X == x && c.Pos.Y == y))
                continue;
            if (polices.Any(p => p.Pos.X == x && p.Pos.Y == y))
                continue;
            if (garage.Pos.X == x && garage.Pos.Y == y)
                continue;

            cars.Add(new Car(x, y));
        }

    }

    void CheckInteraction()
    {
        if
            (player.HasCar)
            {
                garage.TryAccept(player);
               
            }
        else
        {
        foreach (var car in cars)
        {
            car.TrySteal(player);
            if (player.HasCar)
                break;
        
        }
        }
       // garage.TryAccept(player);
    }

}
