namespace Aukcion;

public class Lot
{
    public string Name;
    public int StartPrice;
    public bool IsSold;
    public int  FinalPrice;

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
}
