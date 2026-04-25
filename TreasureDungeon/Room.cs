using System.Globalization;

namespace TreasureDungeon;

public class Room
{
    public Random rnd = new();
    public RoomType roomEvent { get; set; }
    public Room()
    {
        roomEvent = GenerateRoomEvent();
    }

    internal RoomType GenerateRoomEvent()

    {
        roomEvent = (RoomType)rnd.Next(0, 4);

        // Console.WriteLine($"\nТебе выпало {roomEvent}");

        // Console.WriteLine("\n\n=== Проверь что тебе выпало ===");
        // Console.WriteLine("1. Монстр");
        // Console.WriteLine("2. Золото");
        // Console.WriteLine("3. Зелье");
        // Console.WriteLine("4. Пусто\n");


        return roomEvent;


    }
}