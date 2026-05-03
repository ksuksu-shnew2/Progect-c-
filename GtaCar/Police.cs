namespace GtaCar;

public class Police
{
    public Position Pos;
    public Direction Direction = Direction.Right;
    public int DetectionRadius = 5;
    public bool IsChasing = false;

    public Police(int x, int y)
    {
        Pos = new Position(x, y);
    }
    public void Move(Player player, int width, int height)
    {
        if (Math.Abs(player.Pos.X - Pos.X) + Math.Abs(player.Pos.Y - Pos.Y) <= DetectionRadius)
        {
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

        bool hitWall = newPosition.X == 0 || newPosition.X == width - 1 
                || newPosition.Y == 0 || newPosition.Y == height - 1;

        if (hitWall) 
        {
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
