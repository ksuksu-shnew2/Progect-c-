namespace Birzha;

public class Market
{
    public List<Stock> Stocks = new List<Stock>();
    public int Day = 1;

    public Market()
    {
        Stocks.Add(new Stock("Maze Corp",   150, 0.02, 0.001));
        Stocks.Add(new Stock("Bawsaq Inc",  320, 0.05, 0.008));
        Stocks.Add(new Stock("Vangelico",    85, 0.01, 0.012));
        Stocks.Add(new Stock("FlyUS",       210, 0.03, 0.009));
        Stocks.Add(new Stock("Gruppe Six",  440, 0.06, 0.007));
       
    }

    public void NextDay()
    {
        Day++;
        foreach (var stock in Stocks)
        {
            stock.UpdatePrice();
        }
    }

}
