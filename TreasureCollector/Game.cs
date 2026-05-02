namespace TreasureCollector;

public class Game
{
    Player player = new Player(10, 5);
    List<Treasure> treasures = new List<Treasure>();
    List<Guard> guards = new List<Guard>();

    int width = 20;
    int height = 10;
    int score = 0;
    int move = 0;

    public void Start()
    {
           SpawnTreasures();
           SpawnGuards();
            
            while (true)
           {
                ReadInput();

                Position newPositionPlayer = new Position(player.Pos.X, player.Pos.Y);

                if (player.Direction == Direction.Right) newPositionPlayer.X++;
                else if (player.Direction == Direction.Left) newPositionPlayer.X--;
                else if (player.Direction == Direction.Up) newPositionPlayer.Y--;
                else if (player.Direction == Direction.Down) newPositionPlayer.Y++;

              
                
                if (IsWallCollision(newPositionPlayer))
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine($"Score: {score}");
                    return;
                }
                else
                {
                player.Move(newPositionPlayer);
                move++;
                }
           
                //int i = 0;
                foreach (var guard in guards)
                {
                
                // if(IsWallCollision(newPositionGuard))
                // {
                //     if (guard.DirectionGuard == Direction.Right) guard.DirectionGuard = Direction.Left;
                //     else if (guard.DirectionGuard == Direction.Left) guard.DirectionGuard = Direction.Right;
                //     else if (guard.DirectionGuard == Direction.Up) guard.DirectionGuard = Direction.Down;
                //     else if (guard.DirectionGuard == Direction.Down) guard.DirectionGuard = Direction.Up;
                //    // i++;
                // }
                // else
                // {
                //     guard.MoveGuard(newPositionGuard);
                //    // i++;
                // }

                //guard.MoveGuard(newPositionGuard, width, height);

                guard.MoveGuard(width, height);
                
                }
                
                     foreach (var guard in guards)
                    {
                        if (player.Pos.X == guard.Pos.X && player.Pos.Y == guard.Pos.Y)
                        {
                            Console.Clear();
                            Console.WriteLine("GAME OVER");
                            Console.WriteLine($"Score: {score}");
                            return;
                        }
                    }

                foreach (var treasure in treasures)
                {
                    if (!treasure.Collected && player.Pos.X == treasure.Pos.X && player.Pos.Y == treasure.Pos.Y)
                    {
                        treasure.Collected = true;
                        score++;
                        //Console.WriteLine($"Moves: {move}");
                    }
                }
                Draw();
                if (treasures.All(t => t.Collected))
                {
                    Console.Clear();
                    Console.WriteLine("YOU WIN!");
                    Console.WriteLine($"Score: {score}");
                    Console.WriteLine($"Moves: {move}");
                    return;
                }
                //Thread.Sleep(500);

           }

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
    }

    bool IsWallCollision(Position head)
    {
        return head.X == 0 ||
               head.X == width - 1 ||
               head.Y == 0 ||
               head.Y == height - 1;
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
                else if (treasures.Any(t => !t.Collected && t.Pos.X == x && t.Pos.Y == y))
                    Console.Write("$");
                else if (guards.Any(g => g.Pos.X == x && g.Pos.Y == y))
                    Console.Write("!");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
           
        }
         Console.WriteLine($"Score: {score} | Moves: {move}");
    }

    void SpawnTreasures()
    {
        // treasures.Add(new Treasure(3, 2));
        // treasures.Add(new Treasure(7, 4));
        // treasures.Add(new Treasure(12, 6));

        while (treasures.Count < 5)
        {
            int x = Random.Shared.Next(1, width - 1);
            int y = Random.Shared.Next(1, height - 1);

            if (x == player.Pos.X && y == player.Pos.Y)
                continue;
            if (treasures.Any(t => t.Pos.X == x && t.Pos.Y == y))
                continue;

            treasures.Add(new Treasure(x, y));
        }
      
    }
    void SpawnGuards()
    {

        // guards.Add(new HorizontalGuard(x, y));
        // guards.Add(new VerticalGuard(x, y));
        // guards.Add(new Guard(x, y));
        while (guards.Count < 3)
        {
            int x = Random.Shared.Next(1, width - 1);
            int y = Random.Shared.Next(1, height - 1);

            if (x == player.Pos.X && y == player.Pos.Y)
                continue;
            if (treasures.Any(t => t.Pos.X == x && t.Pos.Y == y))
                continue;
            if (guards.Any(g => g.Pos.X == x && g.Pos.Y == y))
                continue;

            if (guards.Count == 0) guards.Add(new HorizontalGuard(x, y));
            else if (guards.Count == 1) guards.Add(new VerticalGuard(x, y));
            else guards.Add(new Guard(x, y));
     }
    }
}

