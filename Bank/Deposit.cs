namespace Bank;

public class Deposit
{
    public string ClientName;
    public int Amount;
    public double InterestRate= 0.05;
    public int DaysLeft;
    public bool IsActive= true;

    public Deposit(string clientName, int amount, int durationDays,double interestRate)
    {
        ClientName = clientName;
        Amount = amount;
        DaysLeft = durationDays;
        InterestRate = interestRate;
    }
    public int ProcessDay()
    {
         if (!IsActive) return 0;
    
            DaysLeft--;
            if (DaysLeft <= 0)
                IsActive = false;
    
        return (int)(Amount * InterestRate);
    }
}
