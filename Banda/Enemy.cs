namespace Banda;

public class Enemy
{
    public int Power = 2;
    public int AttackCooldown = 5;
    public int currentCooldown = 0;
    int totalTicks = 0;

    public Enemy()
    {
        
    }

    public void Update(List<District> districts)
    {
        
        currentCooldown++;
        if (currentCooldown >= AttackCooldown)
            {currentCooldown = 0;
            
                var target = districts[Random.Shared.Next(districts.Count)];
                if (target.Owner != Owner.Enemy)
                {
                    target.TryCapture(Power, Owner.Enemy);
                }
            
            totalTicks++;
            if (totalTicks == 30)
            {
                Power++;
                totalTicks = 0;
            }
            
            }

    }
}
