namespace CityLife;

public class ShopJob : IJob
{
    public Position WarehousePos;
    public Position CashierPos;
    public bool IsComplete { get; private set; } = false;
    int reward = 300;
    public int ItemsDelivered = 0;
    int TotalItems = 3;
    public bool HasItem = false;
    

    public ShopJob(int width, int height)
    {
        WarehousePos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));
        CashierPos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));
    }

    public void Update(Player player)
    {
        if (IsComplete) return;

        if (!HasItem)
        {
            if (player.Pos.X == WarehousePos.X && player.Pos.Y == WarehousePos.Y)
            {
                HasItem = true;
            }
        }
        else
        {
            if (player.Pos.X == CashierPos.X && player.Pos.Y == CashierPos.Y)
            {
                ItemsDelivered++;
                HasItem = false;
                if (ItemsDelivered >= TotalItems)
                {
                    IsComplete = true;
                    player.FinishJob(reward);
                }
            }
        }
    }
}
