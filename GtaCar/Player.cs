namespace GtaCar;

public class Player
{
    public Position Pos;
    public Direction Direction = Direction.Right;
    public bool HasCar = false;
    public int Money = 0;
    public int CarsDelivered = 0;
    public int Speed = 1;
    public int WantedLevel = 0;

    public Player(int x, int y)
    {
        Pos = new Position(x, y);
    }

    public void IncreaseWanted()
    {

        if (WantedLevel < 3)
        {   
            WantedLevel++;
        }
    

    }

      public void DecreaseWanted()
    {

        if (WantedLevel < 4 && WantedLevel > 0) 
        {   
            WantedLevel--;
        }
    

    }

    public bool Move(int width, int height)
    {
        Position newPosition = new Position(Pos.X, Pos.Y);
        Speed = HasCar ? 2 : 1;

        if (Direction == Direction.Right) newPosition.X += 1;
        else if (Direction == Direction.Left) newPosition.X -= 1;
        else if (Direction == Direction.Up) newPosition.Y -= 1;
        else if (Direction == Direction.Down) newPosition.Y += 1;

        bool hitWall = newPosition.X <= 0 || newPosition.X >= width - 1
                    || newPosition.Y <= 0 || newPosition.Y >= height - 1;
        if (hitWall) return false;

        Pos = newPosition;
        return true;
    }

    public void TakeCar()
    {
        HasCar = true;
    }

    public void DeliverCar()
    {
        if (HasCar)
        {
            HasCar = false;
            CarsDelivered++;
            Money += 500;
        }
    }
}