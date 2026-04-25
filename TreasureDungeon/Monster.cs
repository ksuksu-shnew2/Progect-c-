namespace TreasureDungeon;

public class Monster : Character
{
     //Health = 30;
    
    public TypeMonster typeMonster { get; set; }
    public int MaxDamage { get; set; }
    public int MinDamage { get; set; }
     //public Random rnd = new();
    


    public void SetStatsByType()
    {
        (Health, MinDamage, MaxDamage) = typeMonster switch
    {
        TypeMonster.Goblin   => (RandomHelper.Rnd.Next(25, 31), 6, 10),
        TypeMonster.Orc      => (RandomHelper.Rnd.Next(50, 70), 10, 14),
        TypeMonster.Skeleton => (RandomHelper.Rnd.Next(35, 45), 12, 18),
        TypeMonster.Boss     => (RandomHelper.Rnd.Next(100, 200), 18, 30),
        TypeMonster.BossOrc  => (RandomHelper.Rnd.Next(90, 120), 18, 26),
        _ => (0, 0, 0)
    };
       
         
    }
}
