namespace Robbery;

public class HeistPlan
{
    public List<Specialist> Specialists = new List<Specialist>();
    public int Budget = 5000;

    public  HeistPlan()
    {
        Specialists.Add(new Specialist("Артём", Role.Hacker, 2000, 9));
        Specialists.Add(new Specialist("Макс", Role.Cracker, 1500, 8));
        Specialists.Add(new Specialist("Лена", Role.Driver, 1000, 6));
    }

    public bool HireSpecialist(int index)
    {
        if (index < 0 || index >= Specialists.Count) return false;
            var specialist = Specialists[index];
            bool success = specialist.TryHire(Budget);
            if (success)
                Budget -= specialist.Price;
            return success;
    }

    public List<Specialist> HiredSpecialists => Specialists.Where(s => s.IsHired).ToList();
}
