namespace Robbery;

public class HeistStage
{
    public string Name;
    public Role RequiredRole;
    public Position Pos;
    public char Symbol;
    public bool IsComplete;

    public HeistStage(string name, Role requiredRole, int x, int y, char symbol)
    {
        Name = name;
        RequiredRole = requiredRole;
        Pos = new Position(x, y);
        Symbol = symbol;
        IsComplete = false;
    }

    public bool TryExecute(HeistPlan plan)
        {
            var specialist = plan.HiredSpecialists.FirstOrDefault(s => s.Role == RequiredRole);
            
            bool success;
            if (specialist != null)
                success = specialist.AttemptAction();  // шанс по навыку
            else
                success = Random.Shared.Next(1, 11) <= 3;  // низкий шанс без специалиста

            if (success)
            {
                IsComplete = true;
                return true;
            }
            return false;
        }

}
      
