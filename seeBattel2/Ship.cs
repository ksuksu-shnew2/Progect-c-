using System.Reflection.Metadata.Ecma335;

namespace seeBattel2;

internal record class Ship(Line Line, int ShipSize, int StartX, int EndX, int StartY, int EndY);

