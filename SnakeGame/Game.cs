namespace SnakeGame;

public class Game
{
    Snake snake = new Snake();
    Food food = new Food(5, 5);

    int width = 20;
    int height = 10;
    int score = 0;

    public void Start()
    {
        while (true)
        {
            ReadInput();

            Position currentHead = snake.Body[0];
            Position nextHead = new Position(currentHead.X, currentHead.Y);

            if (snake.Direction == Direction.Right) nextHead.X++;
            else if (snake.Direction == Direction.Left) nextHead.X--;
            else if (snake.Direction == Direction.Up) nextHead.Y--;
            else if (snake.Direction == Direction.Down) nextHead.Y++;

            bool willEat = nextHead.X == food.Pos.X && nextHead.Y == food.Pos.Y;

            snake.Move(willEat);

            Position head = snake.Body[0];

            if (IsWallCollision(head) || IsSelfCollision(head))
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
                Console.WriteLine($"Score: {score}");
                return;
            }

            if (willEat)
            {
                score++;
                SpawnFood();
            }

            Draw();
            Console.WriteLine($"Score: {score}");

            Thread.Sleep(500);
        }
    }

    void ReadInput()
    {
        if (!Console.KeyAvailable)
            return;

        ConsoleKey key = Console.ReadKey(true).Key;

        if ((key == ConsoleKey.W || key == ConsoleKey.UpArrow) && snake.Direction != Direction.Down)
    snake.Direction = Direction.Up;

else if ((key == ConsoleKey.S || key == ConsoleKey.DownArrow) && snake.Direction != Direction.Up)
    snake.Direction = Direction.Down;

else if ((key == ConsoleKey.A || key == ConsoleKey.LeftArrow) && snake.Direction != Direction.Right)
    snake.Direction = Direction.Left;

else if ((key == ConsoleKey.D || key == ConsoleKey.RightArrow) && snake.Direction != Direction.Left)
    snake.Direction = Direction.Right;
    }

    bool IsWallCollision(Position head)
    {
        return head.X == 0 ||
               head.X == width - 1 ||
               head.Y == 0 ||
               head.Y == height - 1;
    }

    bool IsSelfCollision(Position head)
    {
        foreach (var part in snake.Body.Skip(1))
        {
            if (head.X == part.X && head.Y == part.Y)
                return true;
        }

        return false;
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
                    Console.Write("#");
                else if (x == food.Pos.X && y == food.Pos.Y)
                    Console.Write("*");
                else if (isSnake)
                    Console.Write("O");
                else
                    Console.Write(" ");
            }

            Console.WriteLine();
        }
    }

    void SpawnFood()
    {
        while (true)
        {
            int x = Random.Shared.Next(1, width - 1);
            int y = Random.Shared.Next(1, height - 1);

            bool insideSnake = false;

            foreach (var part in snake.Body)
            {
                if (part.X == x && part.Y == y)
                {
                    insideSnake = true;
                    break;
                }
            }

            if (!insideSnake)
            {
                food = new Food(x, y);
                return;
            }
        }
    }
}