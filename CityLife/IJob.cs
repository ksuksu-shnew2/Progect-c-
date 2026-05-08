namespace CityLife;

public interface IJob
{
   bool IsComplete { get; }

   void Update(Player player);
    List<(Position pos, char symbol)> GetSymbols();
   
}
