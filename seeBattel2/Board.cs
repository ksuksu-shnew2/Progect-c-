using System.Reflection.Metadata;
using System.Text;

namespace seeBattel2;

internal sealed class Board
{
    private const int BoardSide = 10;
    private const string VerticalCoords = "   А Б В Г Д Е Ж З И К";
    private readonly int[] _ships = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1];

    internal Cell[,] _board;

    public Board(bool autoGenerate)
    {
        _board = new Cell[BoardSide, BoardSide];

        for (int v = 0; v < BoardSide; v++)
        {
            for (int h = 0; h < BoardSide; h++)
            {
                _board[v, h] = new Cell();
            }
        }

        if (autoGenerate)
        {
            GenerateShips();
            return;
        }
    }

    private void GenerateShips()
    {
        foreach (int shipSize in _ships)
        {
            CalculateShip(shipSize);
        }
    }

    private void CalculateShip(int shipSize)
    {
        Random rnd = new();
        Line line = (Line)rnd.Next(0, 2);
        int x, y;
        //Ship ship;
        do
        {
            x = rnd.Next(0, 10);
            y = rnd.Next(0, 10);
            //ship = new Ship(line, shipSize, x, int.MinValue, y, int.MinValue);
        } //while (!TryPlaceShip(ship));
        while (!TryPlaceShip(line,shipSize,x,y));
    }

     private bool TryPlaceShip(Line line, int shipSize, int x,int y)
    {
        //return ship.Line switch
        return Line switch
        {
            // Line.Horizontal => TryPlaceShipHorizontal(ship),
            // Line.Vertical => TryPlaceShipVertical(ship),

            Line.Horizontal => TryPlaceShipHorizontal(shipSize,x,y),
            Line.Vertical => TryPlaceShipVertical(shipSize,x,y),
            _ => true
        };
    }

    private bool TryPlaceShipVertical(Ship ship)
    {
        int lowCoord;
        int highCoord;
        if (_isAutoGenerate)
        {
            lowCoord = ship.StartY > BoardSide - ship.ShipSize
                ? ship.StartY - ship.ShipSize + 1
                : ship.StartY;
            highCoord = ship.StartY > BoardSide - ship.ShipSize
                ? ship.StartY
                : ship.StartY + ship.ShipSize - 1;
        }
        else
        {
            lowCoord = ship.StartY;
            highCoord = ship.EndY;
        }

        int lowIndex = lowCoord - 1 < 0 ? 0 : lowCoord - 1;
        int highIndex = highCoord + 1 > BoardSide - 1
            ? BoardSide - 1
            : highCoord + 1;

        int leftIndex = ship.StartX - 1 < 0 ? 0 : ship.StartX - 1;
        int rightIndex = ship.StartX + 1 > BoardSide - 1
            ? BoardSide - 1
            : ship.StartX + 1;

        if (HasNeighbour(leftIndex, rightIndex, lowIndex, highIndex))
        {
            return false;
        }

        for (int v = lowCoord; v <= highCoord; v++)
        {
            UnderlyingBoard[v, ship.StartX].State = CellState.Unbroken;
        }

        return true;
    }

    private bool TryPlaceShipHorizontal(int shipSize, int x, int y)//(Ship ship)
    {
        int leftCoord = x > BoardSide - ShipSize ? x - ShipSize + 1:x;
        int rightCoord= x > BoardSide - ShipSize ? x : x + ShipSize - 1;

        int leftIndex = leftCoord - 1 < 0 ? 0 : leftCoord - 1;
        int rightIndex = rightCoord + 1 > BoardSide - 1
            ? BoardSide - 1
            : rightCoord + 1;

        int lowIndex = y - 1 < 0 ? 0 : y - 1;
        int highIndex = y + 1 > BoardSide - 1
            ? BoardSide - 1
            : y + 1;


        // if (_isAutoGenerate)
        // {
        //     leftCoord = ship.StartX > BoardSide - ship.ShipSize
        //         ? ship.StartX - ship.ShipSize + 1
        //         : ship.StartX;
        //     rightCoord = ship.StartX > BoardSide - ship.ShipSize
        //         ? ship.StartX
        //         : ship.StartX + ship.ShipSize - 1;
        // }
        // else
        // {
        //     leftCoord = ship.StartX;
        //     rightCoord = ship.EndX;
        // }

        // int leftIndex = leftCoord - 1 < 0 ? 0 : leftCoord - 1;
        // int rightIndex = rightCoord + 1 > BoardSide - 1
        //     ? BoardSide - 1
        //     : rightCoord + 1;

        // int lowIndex = ship.StartY - 1 < 0 ? 0 : ship.StartY - 1;
        // int highIndex = ship.StartY + 1 > BoardSide - 1
        //     ? BoardSide - 1
        //     : ship.StartY + 1;

        if (HasNeighbour(leftIndex, rightIndex, lowIndex, highIndex))
        {
            return false;
        }

        for (int h = leftCoord; h <= rightCoord; h++)
        {
            //UnderlyingBoard[ship.StartY, h].State = CellState.Unbroken;
            _board(y,h).State = CellState.Unbroken;
        }

         return true;
    }

     private bool HasNeighbour(int leftIndex, int rightIndex, int lowIndex, int highIndex)
    {
        for (int v = lowIndex; v <= highIndex; v++)
        {
            for (int h = leftIndex; h <= rightIndex; h++)
            {
                if (UnderlyingBoard[v, h].State == CellState.Unbroken)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void Print()
    {
        StringBuilder sb = new();
        Console.WriteLine(VerticalCoords);
        for (int v = 0; v < BoardSide; v++)
        {
            sb.Clear();
            sb.Append($"{v + 1}".PadRight(3));
            for (int h = 0; h < BoardSide; h++)
            {
                sb.Append(_board[v, h]);
                sb.Append(' ');
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}