namespace TreasureCollector;

public class Guard
{
    public Position Pos;
    public Direction DirectionGuard = Direction.Right;

    public Guard(int x, int y)
    {
        Pos = new Position(x, y);

        // if (DirectionGuard == Direction.Right) Pos.X++;
        // else if (DirectionGuard == Direction.Left) Pos.X--;
        // else if (DirectionGuard == Direction.Up) Pos.Y--;
        // else if (DirectionGuard == Direction.Down) Pos.Y++;
    }

    public virtual void MoveGuard(Position position, int width, int height)
    {
        //Pos = position;
        bool hitWall = position.X == 0 || position.X == width - 1 
                || position.Y == 0 || position.Y == height - 1;

        if (hitWall)
        {
            if (DirectionGuard == Direction.Right) DirectionGuard = Direction.Left;
            else if (DirectionGuard == Direction.Left) DirectionGuard = Direction.Right;
            else if (DirectionGuard == Direction.Up) DirectionGuard = Direction.Down;
            else if (DirectionGuard == Direction.Down) DirectionGuard = Direction.Up;
        }   
        else
        {
            Pos = position;
        }
              
    }
}

    
