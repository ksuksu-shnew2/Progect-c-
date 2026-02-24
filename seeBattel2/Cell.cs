using System;
using System.Runtime.CompilerServices;

namespace seeBattel2;

internal sealed class Cell
{
    public CellState State {get; private set;} = CellState.Empty;
    public override string ToString()
    {
        return State switch
        {
            CellState.Empty or CellState.Alongside or CellState.Unbroken => "*",
            CellState.Damaged or CellState.Destroyed => "x",
            _ => "?"
        };
    }
}
