namespace SnakeGame;

public class Snake
{
    public List<Position> Body = new();
    public Direction Direction = Direction.Right;

    public Snake()
    {
        Body.Add(new Position(10, 5));
        Body.Add(new Position(9, 5));
        Body.Add(new Position(8, 5));
    }

    public void Move(bool grow)
    {
        Position head = Body[0];
        Position newHead = new Position(head.X, head.Y);

        if (Direction == Direction.Right) newHead.X++;
        else if (Direction == Direction.Left) newHead.X--;
        else if (Direction == Direction.Up) newHead.Y--;
        else if (Direction == Direction.Down) newHead.Y++;

        Body.Insert(0, newHead);

        if (!grow)
        {
            Body.RemoveAt(Body.Count - 1);
        }
    }
}