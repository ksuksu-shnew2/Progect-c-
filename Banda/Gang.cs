namespace Banda;

public class Gang
{
    public Position Pos;
    public char Symbol {
        get
        {
            return 'G';
        }
    }
    public District? AssignedDistrict = null;

    public Gang(int x, int y)
        {
            Pos = new Position(x, y);
        }

    public void Update(List<District> districts)
    {
        if (AssignedDistrict != null)
        {
            AssignedDistrict.TryCapture(1, Owner.Player);

            if (Pos.X < AssignedDistrict.Pos.X) Pos.X++;
                else if (Pos.X > AssignedDistrict.Pos.X) Pos.X--;
                else if (Pos.Y < AssignedDistrict.Pos.Y) Pos.Y++;
                else if (Pos.Y > AssignedDistrict.Pos.Y) Pos.Y--;
        }
        else
        {
            var nearest = districts
                .Where(d => d.Owner == Owner.Player)
                .OrderBy(d => Math.Abs(d.Pos.X - Pos.X) + Math.Abs(d.Pos.Y - Pos.Y))
                .FirstOrDefault();
            
            if (nearest != null)
                AssignedDistrict = nearest;
        }
    }
}
