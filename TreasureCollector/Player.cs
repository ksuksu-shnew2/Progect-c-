namespace TreasureCollector;

public class Player
{
   
    public Position Pos;
    public Direction Direction = Direction.Right;

    public Player(int x, int y)
    {
        Pos = new Position(x, y);

        if (Direction == Direction.Right) Pos.X++;
        else if (Direction == Direction.Left) Pos.X--;
        else if (Direction == Direction.Up) Pos.Y--;
        else if (Direction == Direction.Down) Pos.Y++;
    }

    public void Move(Position position)
    {
        Pos = position;
    }
}

