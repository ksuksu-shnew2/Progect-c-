using System.Text;

namespace seeBattel2;

internal sealed class Board
{
    private const int BoardSide = 10;
    private const string VerticalCoords = "   А Б В Г Д Е Ж З И К";

    internal Cell[,] _board;

    public Board()
    {
        _board = new Cell[BoardSide, BoardSide];

        for (int v = 0; v < BoardSide; v++)
        {
            for (int h = 0; h < BoardSide; h++)
            {
                _board[v, h] = new Cell();
            }
        }
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