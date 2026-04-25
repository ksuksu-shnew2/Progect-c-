namespace TreasureDungeon;

public class Monster : Character
{
     //Health = 30;
    public int Damage {get; set; } =0;
    public TypeMonster typeMonster { get; set; }
     //public Random rnd = new();
    


    public void SetStatsByType()
    {
         if (typeMonster == TypeMonster.Goblin)
         {
             Health = RandomHelper.Rnd.Next(25, 31);
             Damage = RandomHelper.Rnd.Next(6, 10);
         }
         else if (typeMonster == TypeMonster.Orc)
         {
             Health = RandomHelper.Rnd.Next(50, 70);
             Damage = RandomHelper.Rnd.Next(10, 14);
         }
         else if (typeMonster == TypeMonster.Skeleton)
         {
             Health = RandomHelper.Rnd.Next(35, 45);
             Damage = RandomHelper.Rnd.Next(12, 18);
         }
         else if (typeMonster == TypeMonster.Boss)
         {
             Health = RandomHelper.Rnd.Next(100, 200);
             Damage = RandomHelper.Rnd.Next(18, 30);
         }
         else if (typeMonster == TypeMonster.BossOrc)
         {
             Health = RandomHelper.Rnd.Next(90, 120);
             Damage = RandomHelper.Rnd.Next(18, 26);
         }
         
    }
}
