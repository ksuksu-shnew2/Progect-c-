namespace TreasureCollector;

public class HorizontalGuard: Guard

{
    //private Direction directionGuard = Direction.Right;

    public HorizontalGuard(int x, int y) : base(x, y)
    {
        DirectionGuard = Direction.Right;
    }
    public override void MoveGuard(int width, int height)
    {
        Position newPositionGuard = new Position(Pos.X, Pos.Y);

                if (DirectionGuard == Direction.Right) newPositionGuard.X++;
                else if (DirectionGuard == Direction.Left) newPositionGuard.X--;
                else if (DirectionGuard == Direction.Up) newPositionGuard.Y--;
                else if (DirectionGuard == Direction.Down) newPositionGuard.Y++;
         bool hitWall = newPositionGuard.X == 0 || newPositionGuard.X == width - 1 
                || newPositionGuard.Y == 0 || newPositionGuard.Y == height - 1;
        if (hitWall)
        {   if (DirectionGuard == Direction.Right) DirectionGuard = Direction.Left;
            else if (DirectionGuard == Direction.Left) DirectionGuard = Direction.Right;
            // else if (DirectionGuard == Direction.Up) DirectionGuard = Direction.Down;
            // else if (DirectionGuard == Direction.Down) DirectionGuard = Direction.Up;
        }   
        else
        {
            Pos = newPositionGuard;
        }    
    }
}
