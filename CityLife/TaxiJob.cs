namespace CityLife;

public class TaxiJob : IJob
{
    public Position PassengerPos;
    public Position DestinationPos;
    public bool IsComplete { get; private set; } = false;
    public bool PassengerPickedUp = false;
    private int reward = 0;


    public TaxiJob(int width, int height)
    {
        //Random rand = new Random();
        PassengerPos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));
        DestinationPos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));

        reward = (Math.Abs(PassengerPos.X - DestinationPos.X) + Math.Abs(PassengerPos.Y - DestinationPos.Y)) * 30;
    }
    
    public void Update(Player player)
    {
        if (IsComplete) return;

        if (!PassengerPickedUp)
        {
            if (player.Pos.X == PassengerPos.X && player.Pos.Y == PassengerPos.Y)
            {
                PassengerPickedUp = true;
            }
        }
        else
        {
            if (player.Pos.X == DestinationPos.X && player.Pos.Y == DestinationPos.Y)
            {
                IsComplete = true;
                player.FinishJob(reward);
            }
        }
    }

}
