namespace Aukcion;

public class Player
{
   public int Balance = 5000;
   public List<Lot> Lots = new List<Lot>();

    public Player()
    {
        Lots.Add(new Lot("Спорткар", 2000));
        Lots.Add(new Lot("Квартира", 3500));
        Lots.Add(new Lot("Бизнес", 1500));
    }
    public void AddMoney(int amount)    
    {
        Balance += amount;
    }

    public List<Lot> AvailableLots => Lots.Where(l => !l.IsSold).ToList();
}
