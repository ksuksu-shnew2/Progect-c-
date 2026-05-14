namespace Aukcion;

public class Lot
{
    public string Name;
    public int StartPrice;
    public bool IsSold;
    public int  FinalPrice;
    public int Attempts = 0;
    public int MaxAttempts = 3;

    public Lot(string name, int startPrice)
    {
        Name = name;
        StartPrice = startPrice;
        IsSold = false;
        FinalPrice = 0;
    }

    public void Sell(int price)
    {
        IsSold = true;
        FinalPrice = price;
    }

    public void Withdraw()
        {
            IsSold = true; 
        }

    public void ReducePrice()
    {
        if (Attempts < MaxAttempts)
        {
            Attempts++;
            StartPrice = (int)(StartPrice * 0.8); 
        }
    }
}
