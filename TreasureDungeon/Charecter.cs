namespace TreasureDungeon;

public class Charecter
{
     public int Health;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }

    }
}
