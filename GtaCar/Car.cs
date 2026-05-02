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
        if (player.Pos.X == Pos.X && player.Pos.Y == Pos.Y && !IsStolen)
        {
            IsStolen = true;
            player.TakeCar();
        }
    }
}
