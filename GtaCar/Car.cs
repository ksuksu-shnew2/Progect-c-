namespace GtaCar;

public class Car
{
    public Position Pos;
    public bool IsStolen = false;

    public Car(int x, int y)
    {
        Pos = new Position(x, y);
    }

    public void TrySteal(Player player)
    {
        if (Math.Abs(player.Pos.X - Pos.X) <= 1
            && Math.Abs(player.Pos.Y - Pos.Y) <= 1
            && !IsStolen)
        {
            IsStolen = true;
            player.TakeCar();
        }
    }

    public void Respawn(int x, int y)
    {
        Pos = new Position(x, y);
        IsStolen = false;
    }
}