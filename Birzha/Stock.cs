namespace Birzha;

public class Stock
{
    public string Name;
    public double Price;
    public double Volatility;
    public List<double> PriceHistory;
    public double PreviousPrice;
    public double DailyTrend;  

    public Stock(string name, double startPrice, double volatility, double dailyTrend = 0.002)
    {
        Name = name;
        Price = startPrice;
        Volatility = volatility;
        PriceHistory = new List<double>();
        PriceHistory.Add(startPrice);
        PreviousPrice = startPrice;
        DailyTrend = dailyTrend;
    }

    public string Trend
    {
        get
        {
            if (Price > PreviousPrice) return "▲";
            else if (Price < PreviousPrice) return "▼";
            else return "—";
        }
    }

    public double Change
    {
        get
        {
            return Price - PreviousPrice;
        }
    }
    public void UpdatePrice()
    {
        PreviousPrice = Price;
        double trendChange = Price * DailyTrend;
        double randomChange = Price * Volatility * (Random.Shared.NextDouble() * 2 - 1) * 0.5;
        Price += trendChange + randomChange;
        if (Price < 1) Price = 1;
        PriceHistory.Add(Price);
    }

}
