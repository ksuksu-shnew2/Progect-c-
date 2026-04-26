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
        public void Move()
        {
            Position head = Body[0];
            Position newHead = new Position(head.X, head.Y);

            if (Direction == Direction.Right)
                newHead.X++;

            if (Direction == Direction.Left)
                newHead.X--;

            if (Direction == Direction.Up)
                newHead.Y--;

            if (Direction == Direction.Down)
                newHead.Y++;

            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }

          public void Grow()
        {
            Position tail = Body[Body.Count - 1];
            Body.Add(new Position(tail.X, tail.Y));
        }
}
