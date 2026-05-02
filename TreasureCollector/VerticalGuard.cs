namespace TreasureCollector;

public class VerticalGuard : Guard
{
    public VerticalGuard(int x, int y) : base(x, y)
    {
        DirectionGuard = Direction.Down;
    }

    public override void MoveGuard(Position position, int width, int height)
    {
        // Implementation for vertical guard movement
        bool hitWall = position.X == 0 || position.X == width - 1 
                || position.Y == 0 || position.Y == height - 1;
        if (hitWall)
        {   
            //          if (DirectionGuard == Direction.Right) DirectionGuard = Direction.Left;
            // else if (DirectionGuard == Direction.Left) DirectionGuard = Direction.Right;
             if (DirectionGuard == Direction.Up) DirectionGuard = Direction.Down;
            else if (DirectionGuard == Direction.Down) DirectionGuard = Direction.Up;
        }   
        else
        {
            Pos = position;
        }       
    }
}
