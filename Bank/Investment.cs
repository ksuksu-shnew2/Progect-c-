namespace Bank;

public class Investment
{
    public string Name;
    public int Amount;
    public RiskLevel Risk;
    public bool IsActive = true;
    public int DaysLeft;

    public Investment(string name, int amount, RiskLevel risk, int durationDays)
    {
        Name = name;
        Amount = amount;
        Risk = risk;
        DaysLeft = durationDays;
    }
    public int ProcessDay()
    {
        if (!IsActive) return 0;

        DaysLeft--;
        if (DaysLeft > 0) return 0;  
        IsActive = false;
        

        int procentLow = Random.Shared.Next(5, 10);
        int procentMedium = Random.Shared.Next(15, 25);
        int procentHigh = Random.Shared.Next(30, 50);

        int randomShans = Random.Shared.Next(0, 10);

        if (Risk == RiskLevel.Low)
            return (int)(Amount * (procentLow / 100.0));
        else if (Risk == RiskLevel.Medium)
            if (randomShans < 6)
                return (int)(Amount * (procentMedium / 100.0));
            else
                return (int)(Amount * (10 / 100.0) * -1);
        else
            if (randomShans < 4)
                    return (int)(Amount * (procentHigh / 100.0));
            else
             return (int)(Amount * (20 / 100.0) * -1);


    }
}
