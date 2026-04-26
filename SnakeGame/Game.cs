namespace SnakeGame;

public class Game
{
    Snake snake = new Snake();
    Food food = new Food(5,5);

    int width = 20;
    int height = 10;

   public void Start()
{
    int score = 0;

    while (true)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.W)
                snake.Direction = Direction.Up;
            else if (key == ConsoleKey.S)
                snake.Direction = Direction.Down;
            else if (key == ConsoleKey.A)
                snake.Direction = Direction.Left;
            else if (key == ConsoleKey.D)
                snake.Direction = Direction.Right;
        }

        snake.Move();

        Position head = snake.Body[0];

        if (head.X == 0 || head.X == width - 1 || head.Y == 0 || head.Y == height - 1)
        {
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine($"Score: {score}");
            return;
        }

        foreach (var part in snake.Body.Skip(1))
        {
            if (head.X == part.X && head.Y == part.Y)
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
                Console.WriteLine($"Score: {score}");
                return;
            }
        }

        if (head.X == food.Pos.X && head.Y == food.Pos.Y)
        {
            snake.Grow();
            SpawnFood();
            score++;
        }

        Draw();
        Console.WriteLine($"Score: {score}");

        Thread.Sleep(500);
    }
}
    
    void Draw()
    {
    Console.Clear();

    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            bool isSnake = false;

            foreach (var part in snake.Body)
            {
                if (part.X == x && part.Y == y)
                {
                    isSnake = true;
                    break;
                }
            }

            if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
            {
                Console.Write("#");
            }
            else if (x == food.Pos.X && y == food.Pos.Y)
            {
                Console.Write("*");
            }
            else if (isSnake)
            {
                Console.Write("O");
            }
            else
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }
}

 void SpawnFood()
    {
        int x = Random.Shared.Next(1, width - 1);
        int y = Random.Shared.Next(1, height - 1);

        food = new Food(x, y);
    }
    

    
}
