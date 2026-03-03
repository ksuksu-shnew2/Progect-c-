namespace seeBattel2;

internal static class Dialog
{

    private static readonly string[] _horizontalCoords =
    ["А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К"];

    private static readonly string[] _verticalCoords =
        ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"];
       internal static PrintMenu()
    {
        Console.WriteLine("\n1. Новая игра");
        Console.WriteLine("2. Загрузить игру");
        Console.WriteLine("3. Сохранить игру");
        Console.WriteLine("0. Выход\n");
        Console.WriteLine("Ваш выбор: ");
    } 

    internal  static GameState ValidateInput()
    {
        string? userInput = Console.ReadLine();

    if(string.IsNullOrWhiteSpace(userInput)
       || !int.TryParse(userInput, out int userChoice)
       || userChoice < (int)GameState.Quit
       || userChoice > (int)GameState.Save)
    {
        Console.WriteLine("Неправильный ввод! Введите число от 0 до 3");
        return GameState.Menu;
    }
    return (GameState)userChoice;
    }
     internal static Ship AskForShip(int shipSize)
    {
        Console.WriteLine($"Размещаем корабль размером {shipSize} палубы");
        Line line = GetDirection();
        
        (int startX, int endX) = GetHorizontalCoords(line, shipSize);
        (int startY, int endY) = GetVerticalCoords(line, shipSize);
        return new Ship(line, shipSize, startX, endX, startY, endY);
    }

    private static (int, int) GetVerticalCoords(Line line, int shipSize)
    {
        while (true)
        {
            if (line == Line.Horizontal || shipSize == 1)
            {
                if (TryGetSingleCoord(CoordType.Single, line, out int coord))
                {
                    return (coord, coord);
                }
                continue;
            }

            TryGetSingleCoord(CoordType.Start, line, out int startY);
            TryGetSingleCoord(CoordType.End, line, out int endY);

            if (startY != int.MinValue
                && endY != int.MinValue
                && startY < endY
                && endY - startY + 1 == shipSize)
            {
                return (startY, endY);
            }

            Console.WriteLine("Введены неправильные координаты!");
        }
    }

    private static (int, int) GetHorizontalCoords(Line line, int shipSize)
    {
        while(true)
        {
        int startX = int.MinValue;
        int endX = int.MinValue;
        string userInput;

        if (line == Line.Vertical || shipSize == 1)
            {
                Console.WriteLine("Введите  координату для коробля по горизонтали ");
                    userInput = Console.ReadLine();

                    if(string.IsNullOrWhiteSpace(userInput)
                    && _horizontalCoords.Contains(userInput))
                    {
                       int coord = Array.IndexOf(_horizontalCoords,userInput);
                       return (coord, coord);
                    }
            }

        Console.WriteLine("Введите начальную координату для коробля по горизонтали ");
        userInput = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(userInput)
       && _horizontalCoords.Contains(userInput))
        {
            startX = Array.IndexOf(_horizontalCoords,userInput);
        }

        Console.WriteLine("Введите конечную координату для коробля по горизонтали ");
        userInput = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(userInput)
       && _horizontalCoords.Contains(userInput))
        {
            endX = Array.IndexOf(_horizontalCoords,userInput);
        }

        if (startX != int.MinValue
                && endX != int.MinValue
                && startX < endX
                && endX - startX + 1 == shipSize)
            {
                return (startX, endX);
            }

        // while (true)
        // {
        //     if (line == Line.Vertical || shipSize == 1)
        //     {
        //         if (TryGetSingleCoord(CoordType.Single, line, out int coord))
        //         {
        //             return (coord, coord);
        //         }
        //         continue;
        //     }

        //     TryGetSingleCoord(CoordType.Start, line, out int startX);
        //     TryGetSingleCoord(CoordType.End, line, out int endX);

        //     if (startX != int.MinValue
        //         && endX != int.MinValue
        //         && startX < endX
        //         && endX - startX + 1 == shipSize)
        //     {
        //         return (startX, endX);
        //     }

            Console.WriteLine("Введены неправильные координаты!");
        }
    }
    internal static bool AutoGenerateUserBoard()
    {
        Console.WriteLine("Расставить ваши корабли в автоматическом режиме?");
        Console.WriteLine("Да - 1, Нет - любая другая клавиша.");
        string? userInput = Console.ReadLine();
        return
            !string.IsNullOrWhiteSpace(userInput)
            && int.TryParse(userInput, out int userChoice)
            && userChoice == 1
            ?Line.Horizontal 
            :Line.Vertical;

        return line;
    }

}
