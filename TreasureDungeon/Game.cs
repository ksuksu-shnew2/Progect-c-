namespace TreasureDungeon;

public class Game
{
    Player player = new Player();

    //public RoomType roomEvent { get; set; }

    GameBattel gameBattel = new GameBattel();

    public void Start()
    {
        while (player.Health > 0)
        {
            Room room = new Room();

            if (room.roomEvent == RoomType.Monster)
            {
                Console.WriteLine("Начинается бой!");
                Monster monster = new();
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

        Console.WriteLine("\nИгра окончена!");
    }
}