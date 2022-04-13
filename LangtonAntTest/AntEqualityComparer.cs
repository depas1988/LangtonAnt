using System;
using System.Collections.Generic;
using System.Text;
using LangtonAnt;

namespace LangtonAntTest
{
    public class AntEqualityComparer : IEqualityComparer<Ant>
    {
        private readonly CoordinateEqualityComparer _coordinateEqualityComparer;

        public AntEqualityComparer(CoordinateEqualityComparer coordinateEqualityComparer)
        {
            _coordinateEqualityComparer = coordinateEqualityComparer;
        }


        public bool Equals(Ant x, Ant y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            return _coordinateEqualityComparer.Equals(x.Coordinate, y.Coordinate);
        }

        public int GetHashCode(Ant obj)
        {
            return (obj.Coordinate != null ? obj.Coordinate.GetHashCode() : 0);
        }
    }


    public class CoordinateEqualityComparer : IEqualityComparer<Coordinate>
    {
        public bool Equals(Coordinate x, Coordinate y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Coordinate obj)
        {
            return HashCode.Combine(obj.X, obj.Y);
        }
    }

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
    
