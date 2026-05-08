namespace CityLife;

public class DeliveryJob : IJob
{
    public Position PackagePos;
    public Position AddressPos;
    public bool IsComplete { get; private set; } = false;
    public bool PackagePickedUp = false;
    int moves = 0;
    int reward = 0;

    public DeliveryJob(int width, int height)
    {
        PackagePos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));
        AddressPos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));
    }

    public void Update(Player player)
    {
        if (IsComplete) return;
        moves++;

        if (!PackagePickedUp)
        {
            if (player.Pos.X == PackagePos.X && player.Pos.Y == PackagePos.Y)
            {
                PackagePickedUp = true;
            }
        }
        else
        {
            if (player.Pos.X == AddressPos.X && player.Pos.Y == AddressPos.Y)
            {
                IsComplete = true;
                reward = Math.Max(100, 500 - moves * 5);
                player.FinishJob(reward);
            }
        }
        //moves++;
    }
}
