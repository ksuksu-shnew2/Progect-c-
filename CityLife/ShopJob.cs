namespace CityLife;

public class ShopJob : IJob
{
    public Position WarehousePos;
    public Position CashierPos;
    public bool IsComplete { get; private set; } = false;
    int reward = 300;
    public int ItemsDelivered = 0;
    public int TotalItems = 3;
    public bool HasItem = false;
    int width;   
    int height;
    

    public ShopJob(int width, int height)
    {
        this.width = width;
        this.height = height;
        WarehousePos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));
        CashierPos = new Position(Random.Shared.Next(1, width - 1), Random.Shared.Next(1, height - 1));
    }

    public void Update(Player player)
    {
        if (IsComplete) return;

    //         Console.SetCursorPosition(0, 21);
    // Console.WriteLine($"P:{player.Pos.X},{player.Pos.Y} W:{WarehousePos.X},{WarehousePos.Y} HasItem:{HasItem}    ");

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
                WarehousePos = new Position(
                    Random.Shared.Next(1, width - 1), 
                    Random.Shared.Next(1, height - 1)
                );
                if (ItemsDelivered >= TotalItems)
                {
                    IsComplete = true;
                    player.FinishJob(reward);
                }
            }
        }
    }
    public List<(Position, char)> GetSymbols()
        {
            var symbols = new List<(Position, char)>();
            if (!HasItem) symbols.Add((WarehousePos, 'W'));
            symbols.Add((CashierPos, 'K'));
            return symbols;
        }
}
