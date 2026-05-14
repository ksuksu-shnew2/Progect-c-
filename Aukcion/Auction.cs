namespace Aukcion;

public class Auction
{
     List<Bidder> Bidders = new List<Bidder>();
    Bidder? Winner= null;
    int CurrentPrice;

    public Auction()
    {

        Bidders.Add(new Bidder("Артём", 5000, BidStrategy.Aggressive));
        Bidders.Add(new Bidder("Макс", 3000, BidStrategy.Careful));
        Bidders.Add(new Bidder("Лена", 4000, BidStrategy.Random));
    }

    public int Run(Lot lot)
    {
        foreach (var b in Bidders) b.IsActive = true;
        CurrentPrice = lot.StartPrice;

        while (Bidders.Count(b => b.IsActive) > 1)
        {
            foreach (var bidder in Bidders.Where(b => b.IsActive).ToList())
            {
                int bid = bidder.MakeBid(CurrentPrice);
                if (bid == -1)
                    Console.WriteLine($"{bidder.Name} пасует.");
                else
                {
                    CurrentPrice = bid;
                    Console.WriteLine($"{bidder.Name} ставит {bid}$");
                }
            }
        }

        Winner = Bidders.FirstOrDefault(b => b.IsActive);
        lot.Sell(CurrentPrice);
        return CurrentPrice;
    }
}
