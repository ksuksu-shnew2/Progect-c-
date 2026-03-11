using System.Reflection.Metadata;
using System.Text;

namespace seeBattel2;

internal sealed class Board
{
    internal const int BoardSide = 10;
    private const string VerticalCoords = "   А Б В Г Д Е Ж З И К";
    private readonly int[] _ships = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1];

    internal Cell[,] UnderlyingBoard { get; private set; }

    //internal Cell[,] _board;

    internal Board(Cell[,] board)
    {
        UnderlyingBoard = board;
    }

     internal bool HasUnbrokenCell()
    {
        for (int v = 0; v < BoardSide; v++)
        {
            for (int h = 0; h < BoardSide; h++)
            {
                if (UnderlyingBoard[v, h].State == CellState.Unbroken)
                {
                    return true;
                }
            }
        }
        return false;
    }

     internal void ChangeCellStatus(int coordY, int coordX, bool success)
    {
        if (success)
        {
            UnderlyingBoard[coordY, coordX].State = CellState.Damaged;
            return;
        }
        UnderlyingBoard[coordY, coordX].State = CellState.OffTarget;
    }

     internal bool CheckHumanMove(int coordY, int coordX)
    {
        if (UnderlyingBoard[coordY, coordX].State == CellState.Unbroken
        || UnderlyingBoard[coordY, coordX].State == CellState.Damaged)
        {
            UnderlyingBoard[coordY, coordX].State = CellState.Damaged;
            return true;
        }

        UnderlyingBoard[coordY, coordX].State = CellState.OffTarget;
        return false;
    }
     internal bool GetUnshottedCell(int coordY, int coordX)
    {
        return
            UnderlyingBoard[coordY, coordX].State != CellState.Damaged
            && UnderlyingBoard[coordY, coordX].State != CellState.OffTarget;
    }

    private readonly bool _isAutoGenerate;

    internal Board(bool autoGenerate, bool isMachineBoard)
    {
        _isAutoGenerate = autoGenerate;

        UnderlyingBoard = new Cell[BoardSide, BoardSide];

        for (int v = 0; v < BoardSide; v++)
        {
            for (int h = 0; h < BoardSide; h++)
            {
                UnderlyingBoard[v, h] = new Cell(isMachineBoard);
            }
        }

        if (autoGenerate)
        {
            GenerateShips();
            return;
        }
          AskForShips();
    }

     private void AskForShips()
    {
        foreach (int shipSize in _ships)
        {
            while (true)
            {
                Ship ship = Dialog.AskForShip(shipSize);
                if (TryPlaceShip(ship))
                {
                    break;
                }

                Console.WriteLine("Выявлено соприкосновение кораблей!");
            }

            Print();
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
        Ship ship;
        do
        {
            x = rnd.Next(0, 10);
            y = rnd.Next(0, 10);
            ship = new Ship(line, shipSize, x, int.MinValue, y, int.MinValue);
        } while (!TryPlaceShip(ship));
        ///while (!TryPlaceShip(line,shipSize,x,y));
    }

     private bool TryPlaceShip(Ship ship)//(Line line, int shipSize, int x,int y)
    {
        //return ship.Line switch
        return ship.Line switch
        {
            // Line.Horizontal => TryPlaceShipHorizontal(ship),
            // Line.Vertical => TryPlaceShipVertical(ship),

            Line.Horizontal => TryPlaceShipHorizontal(ship),//(shipSize,x,y),
            Line.Vertical => TryPlaceShipVertical(ship),//(shipSize,x,y),
            _ => true
        };
    }

    private bool TryPlaceShipVertical(Ship ship)
    {
        // int lowCoord = y > BoardSide - ShipSize ? y - ShipSize + 1:y;
        // int highCoord= y > BoardSide - ShipSize ? y : y + ShipSize - 1;

        // int lowIndex = lowCoord - 1 < 0 ? 0 : lowCoord - 1;
        // int highIndex = highCoord + 1 > BoardSide - 1
        //     ? BoardSide - 1
        //     : highCoord + 1;

        // int leftIndex = x - 1 < 0 ? 0 : x - 1;
        // int rightIndex = x + 1 > BoardSide - 1
        //     ? BoardSide - 1
        //     : x + 1;

        //  if (HasNeighbour(lowIndex, highIndex, leftIndex, rightIndex))
        // {
        //     return false;
        // }

        // for (int h = lowCoord; h <= highCoord; h++)
        // {
        //     //UnderlyingBoard[ship.StartY, h].State = CellState.Unbroken;
        //     _board[y,h].State = CellState.Unbroken;
        // }

        //  return true;

            
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
            //_board[v,ship.StartX].State = CellState.Unbroken;
        }

        return true;
    }

    private bool TryPlaceShipHorizontal(Ship ship)

    {

        // int leftCoord = x > BoardSide - ShipSize ? x - ShipSize + 1:x;
        // int rightCoord= x > BoardSide - ShipSize ? x : x + ShipSize - 1;

        // int leftIndex = leftCoord - 1 < 0 ? 0 : leftCoord - 1;
        // int rightIndex = rightCoord + 1 > BoardSide - 1
        //     ? BoardSide - 1
        //     : rightCoord + 1;

        // int lowIndex = y - 1 < 0 ? 0 : y - 1;
        // int highIndex = y + 1 > BoardSide - 1
        //     ? BoardSide - 1
        //     : y + 1;

        // if (HasNeighbour(leftIndex, rightIndex, lowIndex, highIndex))
        // {
        //     return false;
        // }

        // for (int h = leftCoord; h <= rightCoord; h++)
        // {
        //     //UnderlyingBoard[ship.StartY, h].State = CellState.Unbroken;
        //     _board[y,h].State = CellState.Unbroken;
        // }

        //  return true;
        int leftCoord; 
        int rightCoord;

        if (_isAutoGenerate)
        {
            leftCoord = ship.StartX > BoardSide - ship.ShipSize
                ? ship.StartX - ship.ShipSize + 1
                : ship.StartX;
            rightCoord = ship.StartX > BoardSide - ship.ShipSize
                ? ship.StartX
                : ship.StartX + ship.ShipSize - 1;
        }
        else
        {
            leftCoord = ship.StartX;
            rightCoord = ship.EndX;
        }

        int leftIndex = leftCoord - 1 < 0 ? 0 : leftCoord - 1;
        int rightIndex = rightCoord + 1 > BoardSide - 1
            ? BoardSide - 1
            : rightCoord + 1;

        int lowIndex = ship.StartY - 1 < 0 ? 0 : ship.StartY - 1;
        int highIndex = ship.StartY + 1 > BoardSide - 1
            ? BoardSide - 1
            : ship.StartY + 1;

        if (HasNeighbour(leftIndex, rightIndex, lowIndex, highIndex))
        {
            return false;
        }

        for (int h = leftCoord; h <= rightCoord; h++)
        {
            UnderlyingBoard[ship.StartY, h].State = CellState.Unbroken;
            //_board[ship.StartY,h].State = CellState.Unbroken;
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
                //if (_board[v, h].State == CellState.Unbroken)
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
                sb.Append(UnderlyingBoard[v, h]);
                sb.Append(' ');
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}