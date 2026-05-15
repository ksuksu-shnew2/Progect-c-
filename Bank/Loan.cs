namespace Bank;

public class Loan
{
    public string ClientName;
    public int Amount;
    public double InterestRate = 0.1;
    public int DaysLeft;
    public bool IsOverdue = false;
    public bool IsActive = true;

    public Loan(string clientName, int amount, double interestRate, int durationDays)
    {
        ClientName = clientName;
        Amount = amount;
        InterestRate = interestRate;
        DaysLeft = durationDays;
    }

    public int ProcessDay()
    {
    
        if (!IsActive) return 0;
    
            DaysLeft--;
            if (DaysLeft <= 0)
                {IsOverdue = true;
                IsActive = false;}
    
        return (int)(Amount * InterestRate);
    }

}
