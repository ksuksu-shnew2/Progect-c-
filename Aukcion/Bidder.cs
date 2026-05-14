namespace Aukcion;

public class Bidder
{
    public string Name;
    public int Budget;
    public BidStrategy Strategy;
    public bool IsActive;
    public Bidder(string name, int budget, BidStrategy strategy)
    {
        Name = name;
        Budget = budget;
        Strategy = strategy;
        IsActive = true;
    }

    public int MakeBid(int currentPrice)
    {
         if (!IsActive) return 0;

        // каждый покупатель с шансом 30% пасует просто так
        if (Random.Shared.Next(1, 11) <= 3)
        {
            IsActive = false;
            return -1;
        }

        int bid = 0;
        switch (Strategy)
        {
            case BidStrategy.Aggressive:
                bid = (int)(currentPrice * 1.1);
                break;
            case BidStrategy.Careful:
                bid = (int)(currentPrice * 1.03);
                break;
            case BidStrategy.Random:
                bid = (int)(currentPrice * (1 + Random.Shared.Next(3, 12) / 100.0));
                break;
        }

        if (bid > Budget) 
        {
            IsActive = false;
            return -1;
        }

        return bid;
    }
}
