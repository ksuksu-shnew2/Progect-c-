namespace Robbery;

public class Specialist
{
    public string Name;
    public Role Role;
    public int Price;
    public int Skill;
    public bool IsHired = false;

    public Specialist(string name, Role role, int price, int skill)
    {
        Name = name;
        Role = role;
        Price = price;
        Skill = skill;
    }
    public bool TryHire(int budget)
    {
        if (IsHired)
        {
            return false;
        }
        if (budget >= Price)
        {
            IsHired = true;
            return true;
        }
        return false;
    }

    public bool AttemptAction()
    {
        if (IsHired == false)
        {
            return Random.Shared.Next(1, 11) <= 3;
            
        }
        else
        {
            return Random.Shared.Next(1, 11) <= Skill;
        }
    }
}
