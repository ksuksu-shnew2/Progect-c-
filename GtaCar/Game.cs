namespace GtaCar;

public class Game
{
    public Player player = new Player(10, 4);
    public List<Car> cars;
    public List<Police> polices;
    public Garage garage;
    public int width = 40;
    public int height = 15;  
    public int score = 0;
    public int move = 0;

    public void Start()
    {
        SpawnAll();
        Draw();

        // while (true)
        // {
        //     ReadInput();
        //     Player.Move(Width, Height);
        //     foreach (var police in Polices)
        //     {
        //         police.Move(Player, Width, Height);
        //         if (Player.Pos.X == police.Pos.X && Player.Pos.Y == police.Pos.Y)
        //         {
        //             Console.Clear();
        //             Console.WriteLine("GAME OVER");
        //             return;
        //         }
        //     }
        //     foreach (var car in Cars)
        //     {
        //         car.TrySteal(Player);
        //     }
        //     Garage.TryAccept(Player);
       // }
    }

    void ReadInput()
    {
        // if (Console.ReadKey(true).Key == ConsoleKey.Escape)
        //     return;

        ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.W || key == ConsoleKey.UpArrow) player.Direction = Direction.Up;

            else if ((key == ConsoleKey.S || key == ConsoleKey.DownArrow)) player.Direction = Direction.Down;

            else if ((key == ConsoleKey.A || key == ConsoleKey.LeftArrow)) player.Direction = Direction.Left;

            else if ((key == ConsoleKey.D || key == ConsoleKey.RightArrow))  player.Direction = Direction.Right;
            //else if (key == ConsoleKey.E) CheckInteraction();
            else if (key == ConsoleKey.Escape) return;
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
                else if (x == player.Pos.X && y == player.Pos.Y && player.HasCar == true)
                    Console.Write("*");
                else if (x == garage.Pos.X && y == garage.Pos.Y)
                    Console.Write("G");
                else if (cars.Any(t => t.Pos.X == x && t.Pos.Y == y))
                    Console.Write("$");
                else if (polices.Any(g => g.Pos.X == x && g.Pos.Y == y))
                    Console.Write("!");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
           
        }
         Console.WriteLine($"Score: {score} | Moves: {move}");
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

}
