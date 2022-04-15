using System;
using System.Collections.Generic;
using LangtonAnt.DataModel;

namespace LangtonAntTest.Utility
{
    public class CellEqualityComparer : IEqualityComparer<Cell>
    {
        private readonly CoordinateEqualityComparer _coordinateEqualityComparer;

        public CellEqualityComparer(CoordinateEqualityComparer coordinateEqualityComparer)
        {
            _coordinateEqualityComparer = coordinateEqualityComparer;
        }

        public bool Equals(Cell x, Cell y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            return x.Color == y.Color && _coordinateEqualityComparer.Equals(x.Coordinate, y.Coordinate);
        }

        public int GetHashCode(Cell obj)
        {
            return HashCode.Combine((int) obj.Color, obj.Coordinate);
        }
    }
}