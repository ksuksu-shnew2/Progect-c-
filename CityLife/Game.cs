namespace CityLife;

public class Game
{
    public Player player = new Player(20, 10);
    List<Building> buildings;
    int width = 40;
    int height = 20;

    public void Start()
    {
        SpawnBuildings();
        Draw();
        while (true)
        {
            bool moved = ReadInput();
            if (moved)
                player.Move(width, height);

            Console.SetCursorPosition(0, 22);  // ← сюда
  
            //     if (player.IsWorking)
            // {
            //     var job = player.CurrentJob;
            //     job.Update(player);
            //     if (job.IsComplete)
            //         player.CurrentJob = null;
            // }

            Draw();

    //         Console.WriteLine($"IsWorking:{player.IsWorking} Job:{player.CurrentJob?.GetType().Name}");

    //         if (player.CurrentJob is ShopJob s)
    // Console.WriteLine($"P:{player.Pos.X},{player.Pos.Y} W:{s.WarehousePos.X},{s.WarehousePos.Y} HasItem:{s.HasItem}Items: {s.ItemsDelivered}/{s.TotalItems} Complete:{s.IsComplete}");

            if (player.Money >= 5000)
            {
                Console.WriteLine("ПОБЕДА!");
                return;
            }
        }
    }

    bool ReadInput()
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
        {
            player.Direction = Direction.Up;
            return true;
        }
        if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
        {
            player.Direction = Direction.Down;
            return true;
        }
        if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
        {
            player.Direction = Direction.Left;
            return true;
        }
        if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
        {
            player.Direction = Direction.Right;
            return true;
        }
        if (key == ConsoleKey.F)
        {
            CheckInteraction();
            return false;
        }
        return false;
    }

    void CheckInteraction()
    {
    //     Console.SetCursorPosition(0, 22);
    // Console.WriteLine($"IsWorking: {player.IsWorking}");

        if (player.IsWorking) //player.CurrentJob.Update(player);
        {var job = player.CurrentJob;
                job.Update(player);
               if (job.IsComplete)
                    player.CurrentJob = null;}
 
        else
        {
            var building = buildings.FirstOrDefault(b => Math.Abs(b.Pos.X - player.Pos.X) <= 1 && Math.Abs(b.Pos.Y - player.Pos.Y) <= 1);;
            
        //     Console.SetCursorPosition(0, 23);
        // Console.WriteLine($"Building: {building?.Type} | PlayerPos: {player.Pos.X},{player.Pos.Y}");
        
            
            if (building != null)
            {
                if (building.Type == JobType.Taxi)
                    player.TakeJob(new TaxiJob(width, height));
                else if (building.Type == JobType.Shop)
                    player.TakeJob(new ShopJob(width, height));
                else if (building.Type == JobType.Delivery)
                    player.TakeJob(new DeliveryJob(width, height));
            }
        }
    
    }

    void SpawnBuildings()
    {
        buildings = new List<Building>();
        JobType[] types = { JobType.Taxi, JobType.Shop, JobType.Delivery };

        foreach (var type in types)
        {
            while (true)
            {
                int x = Random.Shared.Next(1, width - 1);
                int y = Random.Shared.Next(1, height - 1);

                if (x == player.Pos.X && y == player.Pos.Y) continue;
                if (buildings.Any(b => b.Pos.X == x && b.Pos.Y == y)) continue;

                buildings.Add(new Building(x, y, type));
                break;
            }
        }
    }
    void Draw()
    {
        Console.Clear();
        for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
            Console.Write("#");
        
        else if (x == player.Pos.X && y == player.Pos.Y)
            Console.Write("@");
        
        else if (player.CurrentJob is TaxiJob taxi
                 && !taxi.PassengerPickedUp
                 && x == taxi.PassengerPos.X && y == taxi.PassengerPos.Y)
            Console.Write("P");
        
        else if (player.CurrentJob is TaxiJob taxi2
                 && taxi2.PassengerPickedUp
                 && x == taxi2.DestinationPos.X && y == taxi2.DestinationPos.Y)
            Console.Write("X");
        
        else if (player.CurrentJob is ShopJob shop
                && !shop.HasItem
                 && x == shop.WarehousePos.X && y == shop.WarehousePos.Y)
            Console.Write("W");
        
        else if (player.CurrentJob is ShopJob shop2
                //&& !shop2.HasItem
                 && x == shop2.CashierPos.X && y == shop2.CashierPos.Y)
            Console.Write("K");
        
        else if (player.CurrentJob is DeliveryJob delivery
                 && !delivery.PackagePickedUp
                 && x == delivery.PackagePos.X && y == delivery.PackagePos.Y)
            Console.Write("B");
        
        else if (player.CurrentJob is DeliveryJob delivery2
                 && delivery2.PackagePickedUp
                 && x == delivery2.AddressPos.X && y == delivery2.AddressPos.Y)
            Console.Write("A");
        
        else if (buildings.Any(b => b.Pos.X == x && b.Pos.Y == y))
            Console.Write(buildings.First(b => b.Pos.X == x && b.Pos.Y == y).Symbol);
        
        else
            Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Деньги: {player.Money} | Цель: 5000 | F - взять работу");

    }
    

}
