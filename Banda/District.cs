namespace Banda;

public class District
{
   public Position Pos;
   public Owner Owner = Owner.Neutral;
   public int Defense;
   public int Income;
   public char Symbol {
        get
        {
            return Owner switch
            {
                Owner.Neutral => 'N',
                Owner.Player => 'P',
                Owner.Enemy => 'E',
                _ => '?'
            };
        }
    }

    public District(int x, int y)
    {
        Pos = new Position(x, y);
        Defense = Random.Shared.Next(1, 5);
        Income = Random.Shared.Next(50, 200);
    }

    public bool TryCapture(int attackPower, Owner attacker)
    {
        if (attackPower >= Defense)
        {
            Owner = attacker;
            return true;
        }
        return false;
    }
}
