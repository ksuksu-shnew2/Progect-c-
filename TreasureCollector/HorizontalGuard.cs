namespace TreasureCollector;

public class HorizontalGuard: Guard

{
    //private Direction directionGuard = Direction.Right;

    public HorizontalGuard(int x, int y) : base(x, y)
    {
        DirectionGuard = Direction.Right;
    }
    public override void MoveGuard(Position position, int width, int height)
    {
         bool hitWall = position.X == 0 || position.X == width - 1 
                || position.Y == 0 || position.Y == height - 1;
        if (hitWall)
        {   if (DirectionGuard == Direction.Right) DirectionGuard = Direction.Left;
            else if (DirectionGuard == Direction.Left) DirectionGuard = Direction.Right;
            // else if (DirectionGuard == Direction.Up) DirectionGuard = Direction.Down;
            // else if (DirectionGuard == Direction.Down) DirectionGuard = Direction.Up;
        }   
        else
        {
            Pos = position;
        }    
    }
}
