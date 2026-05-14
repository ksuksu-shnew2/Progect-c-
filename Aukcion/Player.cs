namespace Aukcion;

public class Player
{
   public int Balance = 5000;
   public List<Lot> Lots = new List<Lot>();
   public int Reputation = 0;

    public Player()
    {
        Lots.Add(new Lot("Спорткар", 2000));
        Lots.Add(new Lot("Квартира", 3500));
        Lots.Add(new Lot("Бизнес", 1500));
        Lots.Add(new Lot("Яхта", 4500));
        Lots.Add(new Lot("Самолёт", 4800));
        Lots.Add(new Lot("Пентхаус", 4000));
        Lots.Add(new Lot("Ресторан", 2500));
        Lots.Add(new Lot("Завод", 3000));
        Lots.Add(new Lot("Клуб", 2000));
        Lots.Add(new Lot("Отель", 4500));
    }
    public void AddMoney(int amount)    
    {
        Balance += amount;
    }

    public void AddReputation(int amount)
    {
        Reputation += amount;
    }

    public List<Lot> AvailableLots => Lots.Where(l => !l.IsSold).ToList();

    public double ReputationBonus
    {
        get
        {
            if (Reputation >= 10) return 1.5;
            if (Reputation >= 6) return 1.25;
            if (Reputation >= 3) return 1.1;
            return 1.0;
        }
    }
}
