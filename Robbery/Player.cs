namespace Robbery;

public class Player
{
    public Position Pos;
    public Direction Direction = Direction.Right;

    public Player(int x, int y)
    {
        Pos = new Position(x, y);
    }
   public bool Move(int width,int height)
    {
        switch (Direction)
        {
            case Direction.Up: Pos.Y = Math.Max(1, Pos.Y - 1); break;
            case Direction.Down: Pos.Y = Math.Min(height - 2, Pos.Y + 1); break;
            case Direction.Left: Pos.X = Math.Max(1, Pos.X - 1); break;
            case Direction.Right: Pos.X = Math.Min(width - 2, Pos.X + 1); break;
        }
        return true;
    }
}
