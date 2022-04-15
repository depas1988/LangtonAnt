using System;
using System.Collections.Generic;
using LangtonAnt.DataModel;

namespace LangtonAntTest.Utility
{
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
}