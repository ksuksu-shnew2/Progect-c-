namespace CityLife;

public class Building
{
    public Position Pos;
    public JobType Type;
    public char Symbol { 
        get
        {
            return Type switch
            {
                JobType.Taxi => 'T',
                JobType.Shop => 'S',
                JobType.Delivery => 'D',
                _ => '?'
            };
        }
    }

    public Building(int x, int y, JobType type)
    {
        Pos = new Position(x, y);
        Type = type;
    }

}
