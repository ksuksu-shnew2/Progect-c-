namespace GtaCar;

public class Police
{
    public Position Pos;
    public Direction Direction;
    public int DetectionRadius = 5;
    public bool IsChasing = false;
    public int ChaseMemory = 0;
    public const int ChaseMemoryTurns = 3;

    public Police(int x, int y)
    {
        Pos = new Position(x, y);
        Direction = (Direction)Random.Shared.Next(0, 4);
    }

    public void Move(Player player, int width, int height, Garage garage, List<Police> allPolices)
    {
        bool inRadius = Math.Abs(player.Pos.X - Pos.X) + Math.Abs(player.Pos.Y - Pos.Y) <= DetectionRadius;

        if (inRadius)
        {
            IsChasing = true;
            ChaseMemory = ChaseMemoryTurns;
        }
        else if (ChaseMemory > 0)
        {
            ChaseMemory--;
            IsChasing = true;
        }
        else
        {
            IsChasing = false;
        }

        if (IsChasing)
        {
            if (player.Pos.X < Pos.X) Direction = Direction.Left;
            else if (player.Pos.X > Pos.X) Direction = Direction.Right;
            else if (player.Pos.Y < Pos.Y) Direction = Direction.Up;
            else if (player.Pos.Y > Pos.Y) Direction = Direction.Down;
        }

        Position newPosition = new Position(Pos.X, Pos.Y);
        if (Direction == Direction.Right) newPosition.X++;
        else if (Direction == Direction.Left) newPosition.X--;
        else if (Direction == Direction.Up) newPosition.Y--;
        else if (Direction == Direction.Down) newPosition.Y++;

        bool hitWall = newPosition.X <= 0 || newPosition.X >= width - 1
                    || newPosition.Y <= 0 || newPosition.Y >= height - 1;
        bool hitGarage = newPosition.X == garage.Pos.X && newPosition.Y == garage.Pos.Y;
        bool hitPolice = allPolices.Any(p => p != this && p.Pos.X == newPosition.X && p.Pos.Y == newPosition.Y);

        if (hitWall || hitGarage || hitPolice)
        {
            // отскакиваем от стены/препятствия
            if (Direction == Direction.Right) Direction = Direction.Left;
            else if (Direction == Direction.Left) Direction = Direction.Right;
            else if (Direction == Direction.Up) Direction = Direction.Down;
            else if (Direction == Direction.Down) Direction = Direction.Up;
        }
        else
        {
            Pos = newPosition;
        }
    }
}