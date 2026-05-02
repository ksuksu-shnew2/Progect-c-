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
        if (player.Pos.X == Pos.X && player.Pos.Y == Pos.Y && player.HasCar)
        {
            player.DeliverCar();
        }
    }
}
