namespace TreasureDungeon;

public class Monster : Character
{
     //Health = 30;
    public int Damage {get; set; } =0;
    public TypeMonster typeMonster { get; set; }
     //public Random rnd = new();
    


    public void SetStatsByType()
    {
        (Health, Damage) = typeMonster switch
    {
        TypeMonster.Goblin   => (RandomHelper.Rnd.Next(25, 31), RandomHelper.Rnd.Next(6, 10)),
        TypeMonster.Orc      => (RandomHelper.Rnd.Next(50, 70), RandomHelper.Rnd.Next(10, 14)),
        TypeMonster.Skeleton => (RandomHelper.Rnd.Next(35, 45), RandomHelper.Rnd.Next(12, 18)),
        TypeMonster.Boss     => (RandomHelper.Rnd.Next(100, 200), RandomHelper.Rnd.Next(18, 30)),
        TypeMonster.BossOrc  => (RandomHelper.Rnd.Next(90, 120), RandomHelper.Rnd.Next(18, 26)),
        _ => (0, 0)
    };
       
         
    }
}
