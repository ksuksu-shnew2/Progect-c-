namespace TreasureDungeon;

public class Game
{
    Player player = new Player();
    public Random rnd = new();

    //public RoomType roomEvent { get; set; }

    GameBattel gameBattel = new GameBattel();

    int countRooms = 0;

    public void Start()
    {
        while (player.Health > 0)
        {
            Room room = new Room();
            countRooms++;
            Console.WriteLine($"\nСледующая комната: {countRooms}");

            if (room.roomEvent == RoomType.Monster)
            {
                Console.WriteLine("Начинается бой!");
                Monster monster = new();
                if (countRooms >= 1 && countRooms <= 4)
                {monster.Health = 30;
                monster.Damage = rnd.Next(8, 13);
                Console.WriteLine($"\nМонстр имеет {monster.Health} здоровья и наносит  {monster.Damage} урона.");
                }
                else if (countRooms >= 5 && countRooms <= 9)
                {
                    monster.Health = 40;
                    monster.Damage = rnd.Next(10, 14);
                    Console.WriteLine($"\nМонстр имеет {monster.Health} здоровья и наносит  {monster.Damage} урона.");
                }
                else if (countRooms >= 10 && countRooms <= 14)
                {
                    monster.Health = 50;
                    monster.Damage = rnd.Next(12, 28);
                    Console.WriteLine($"\nМонстр имеет {monster.Health} здоровья и наносит  {monster.Damage} урона.");
                }
                else if (countRooms >= 15)
                {
                    monster.Health = 70;
                    monster.Damage = rnd.Next(15, 22);
                    Console.WriteLine($"\nМонстр имеет {monster.Health} здоровья и наносит  {monster.Damage} урона.");
                }
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
}