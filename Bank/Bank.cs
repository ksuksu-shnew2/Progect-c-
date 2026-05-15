namespace Bank;

public class Bank
{
    public int Capital = 50000;
    public List<Loan> Loans = new List<Loan>();
    public List<Deposit> Deposits = new List<Deposit>();
    public int Day = 1;
    public List<Investment> Investments = new List<Investment>();

    public Bank()
    {
        Deposits = new List<Deposit>();
        Loans = new List<Loan>();
        Investments = new List<Investment>();
    }

    public void NextDay()
    {
        Day++;
        foreach (var deposit in Deposits)
            Capital -= deposit.ProcessDay();

        foreach (var loan in Loans)
            Capital += loan.ProcessDay();

        foreach (var investment in Investments)
            Capital += investment.ProcessDay();
    }

    public bool AddDeposit(string client, int amount, double rate, int days)
    {
        if (Capital >= amount) 
        {Capital -= amount;
        Deposits.Add(new Deposit(client, amount, days, rate));
        return true;}
        return false;
    }
    public bool AddLoan(string client, int amount, double rate, int days)
    {
        if (Capital >= amount) 
        {Capital -= amount;
        Loans.Add(new Loan(client, amount, rate, days));
        return true;}
        return false;
    }
    public bool AddInvestment(string name, int amount, RiskLevel risk, int days)
    {if (Capital >= amount) 
        {Capital -= amount;
        Investments.Add(new Investment(name, amount, risk, days));
        return true;}
        return false;
    }
}
