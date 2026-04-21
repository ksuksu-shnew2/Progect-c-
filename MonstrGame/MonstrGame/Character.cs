using System.Net.Mail;

namespace MonstrGame;

public class Character
{
    public int Health = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
        }

    }
}
