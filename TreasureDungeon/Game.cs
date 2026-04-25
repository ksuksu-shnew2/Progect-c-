namespace TreasureDungeon;

public class Game
{
    Player player = new Player();
    //public Random rnd = new();

    //public RoomType roomEvent { get; set; }

    GameBattle GameBattle = new GameBattle();

    int countRooms = 0;

    public void Start()
    {
        while (player.Health > 0)
        {
            Room room = new Room();
            //var roomEvent = room.GenerateRoomEvent();
            Console.WriteLine($"\nТебе выпало {room.roomEvent}");
            int Ran;
            countRooms++;
            Console.WriteLine($"\nСледующая комната: {countRooms}");

            if (room.roomEvent == RoomType.Monster)
            {
                Console.WriteLine("Начинается бой!");
                Monster monster = new();
                
                switch (countRooms)
                    {
                        case int n when n % 5 == 0:
                            monster.typeMonster = TypeMonster.Boss;
                            break;

                        case int n when n <= 4:
                            Ran = RandomHelper.Rnd.Next(0, 100);
                            monster.typeMonster = Ran < 70 
                                ? TypeMonster.Goblin 
                                : TypeMonster.Skeleton;
                            break;

                        case int n when n <= 9:
                            Ran = RandomHelper.Rnd.Next(0, 100);
                            if (Ran < 40)
                                monster.typeMonster = TypeMonster.Goblin;
                            else if (Ran < 80)
                                monster.typeMonster = TypeMonster.Skeleton;
                            else
                                monster.typeMonster = TypeMonster.Orc;
                            break;

                        default: // 10+ (кроме боссов)
                            Ran = RandomHelper.Rnd.Next(0, 100);
                            if (Ran < 30)
                                monster.typeMonster = TypeMonster.Skeleton;
                            else if (Ran < 80)
                                monster.typeMonster = TypeMonster.Orc;
                            else
                                monster.typeMonster = TypeMonster.BossOrc;
                            break;
                    }
               
                monster.SetStatsByType();
                Console.WriteLine($"Тебе выпал монстр {monster.typeMonster} с {monster.Health} здоровье и наносит {monster.MinDamage}-{monster.MaxDamage} урона.");

                GameBattle.StartBattle(player, monster);
            }

            else if (room.roomEvent == RoomType.Gold)
            {
                player.AddGold(10);
            }

            else if (room.roomEvent == RoomType.Potion)
            {
                player.UseHealthPotion();
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

    
}