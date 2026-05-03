namespace GtaCar;

public class Garage
{
    public Position Pos;

    public Garage(int x, int y) 
    {
        Pos = new Position(x, y);
    }

    public void TryAccept(Player player)
    {
        if (Math.Abs(player.Pos.X - Pos.X) <= 1 && Math.Abs(player.Pos.Y - Pos.Y) <= 1 && player.HasCar)
        {
            player.DeliverCar();
        }
    }
}
