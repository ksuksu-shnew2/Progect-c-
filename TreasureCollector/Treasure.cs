namespace TreasureCollector;

public class Treasure
{
    public Position Pos { get; set; }
    public bool Collected { get; set; }

    public Treasure(int x, int y)
    {
        Pos = new Position(x, y);
        Collected = false;
    }
}
