namespace TreasureCollector;

public class Player : IMovable
{
   
    public Position Pos;
    public Direction Direction = Direction.Right;

    public Player(int x, int y) 
    {
        Pos = new Position(x, y);

    }

    public bool Move(int width, int height)
    {
        Position newPosition = new Position(Pos.X, Pos.Y);

        if (Direction == Direction.Right) newPosition.X++;
        else if (Direction == Direction.Left) newPosition.X--;
        else if (Direction == Direction.Up) newPosition.Y--;
        else if (Direction == Direction.Down) newPosition.Y++;

        bool hitWall = newPosition.X == 0 || newPosition.X == width - 1 
                || newPosition.Y == 0 || newPosition.Y == height - 1;
        if (hitWall) return false;
        
            Pos = newPosition;
            return true;
    }
}

