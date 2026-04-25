namespace TreasureDungeon;

public class Character
{
     public int Health { get; set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }

    }
}
