namespace Birzha;

public class Portfolio
{
    public double Cash = 10000;
    public Dictionary<Stock, int> Holdings = new Dictionary<Stock, int>();

    public Portfolio()
    {
       Holdings = new Dictionary<Stock, int>(); 
    }

    public bool Buy(Stock stock, int quantity)
    {
        double totalCost = stock.Price * quantity;
        if (Cash>= totalCost)
        {
            Cash -= totalCost;
        }
        else
        {
            return false;
        }

        if (Holdings.ContainsKey(stock))
            {Holdings[stock] += quantity;
            return true;}
        else
            {Holdings[stock] = quantity;
            return true;}
    }

    public double TotalValue => Cash + Holdings.Sum(h => h.Key.Price * h.Value);

    public int GetQuantity(Stock stock)
    {
        if (Holdings.ContainsKey(stock))
            return Holdings[stock];
        else
            return 0;
    }

    public bool Sell(Stock stock, int quantity)
    {
        if (Holdings.ContainsKey(stock) && Holdings[stock] >= quantity)
        {
            double totalRevenue = stock.Price * quantity;
            Cash += totalRevenue;
            Holdings[stock] -= quantity;
            if (Holdings[stock] == 0)
                Holdings.Remove(stock);
            return true;
        }
        else
        {
            return false;
        }
    }
}
