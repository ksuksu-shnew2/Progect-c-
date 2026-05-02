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

    public virtual void MoveGuard(int width, int height)
    {
        Position newPositionGuard = new Position(Pos.X, Pos.Y);

                if (DirectionGuard == Direction.Right) newPositionGuard.X++;
                else if (DirectionGuard == Direction.Left) newPositionGuard.X--;
                else if (DirectionGuard == Direction.Up) newPositionGuard.Y--;
                else if (DirectionGuard == Direction.Down) newPositionGuard.Y++;
        //Pos = position;
        bool hitWall = newPositionGuard.X == 0 || newPositionGuard.X == width - 1 
                || newPositionGuard.Y == 0 || newPositionGuard.Y == height - 1;

        if (hitWall)
        {
            if (DirectionGuard == Direction.Right) DirectionGuard = Direction.Left;
            else if (DirectionGuard == Direction.Left) DirectionGuard = Direction.Right;
            else if (DirectionGuard == Direction.Up) DirectionGuard = Direction.Down;
            else if (DirectionGuard == Direction.Down) DirectionGuard = Direction.Up;
        }   
        else
        {
            Pos = newPositionGuard;
        }
              
    }
}

    
