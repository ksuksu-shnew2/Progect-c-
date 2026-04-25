namespace TreasureDungeon;

public class Game
{
    Player player = new Player();
    //public Random rnd = new();

    //public RoomType roomEvent { get; set; }

    GameBattel gameBattel = new GameBattel();

    int countRooms = 0;

    public void Start()
    {
        while (player.Health > 0)
        {
            Room room = new Room();
                int Ran;
            countRooms++;
            Console.WriteLine($"\nСледующая комната: {countRooms}");

            if (room.roomEvent == RoomType.Monster)
            {
                Console.WriteLine("Начинается бой!");
                Monster monster = new();
                
                 if (countRooms % 5 == 0)
                 {
                    monster.typeMonster = TypeMonster.Boss;
                }
                else if (countRooms >= 1 && countRooms <= 4)
                {
                    Ran = RandomHelper.Rnd.Next(0, 100);
                    if (Ran < 70)
                    {
                        monster.typeMonster = TypeMonster.Goblin;

                    }
                    else if (Ran >= 70 && Ran < 100)
                    {
                        monster.typeMonster = TypeMonster.Skeleton;  
                    }
                }
                else if (countRooms >= 6 && countRooms <= 9)
                {
                    {
                    Ran = RandomHelper.Rnd.Next(0, 100);
                    if (Ran < 40)
                    {
                        monster.typeMonster = TypeMonster.Goblin;

                    }
                    else if (Ran >= 40 && Ran < 80)
                    {
                        monster.typeMonster = TypeMonster.Skeleton;  
                    }
                    else if (Ran >= 80 && Ran < 100)
                    {
                        monster.typeMonster = TypeMonster.Orc;  
                    }
                    }
                }
                
                else if (countRooms > 10)
                {
                   {
                    Ran = rnd.Next(0, 100);
                    if (Ran < 30)
                    {
                        monster.typeMonster = TypeMonster.Skeleton;
                    }
                    else if (Ran >= 30 && Ran < 80)
                    {
                        monster.typeMonster = TypeMonster.Orc;  
                        
                    }
                    else if (Ran >= 80 && Ran < 100)
                    {
                        monster.typeMonster = TypeMonster.BossOrc;   
                    }
                    }
                }
                monster.SetStatsByType();
                Console.WriteLine($"Тебе выпал монстр {monster.typeMonster} с {monster.Health} здоровье и наносит {monster.Damage} урона.");

                gameBattel.StartBattle(player, monster);
            }

            else if (room.roomEvent == RoomType.Gold)
            {
                player.AddGold(10);
            }

            else if (room.roomEvent == RoomType.Potion)
            {
                player.Heal();
            }

            else
            {
                Console.WriteLine("Комната пуста.");
            }

            Console.WriteLine("\nНажми Enter чтобы идти дальше...");
            Console.ReadLine();
        }

        Console.WriteLine($"\nИгра окончена! Ты прошел {countRooms} комнат.");
    }

    public static class RandomHelper
        {
            public static readonly Random Rnd = new();
        }
}