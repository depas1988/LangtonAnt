using System.Collections.Generic;
using LangtonAnt.DataModel;

namespace LangtonAntTest.Utility
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

            return _coordinateEqualityComparer.Equals(x.Coordinate, y.Coordinate) && x.Direction.Equals(y.Direction);
        }

        public int GetHashCode(Ant obj)
        {
            return (obj.Coordinate != null ? obj.Coordinate.GetHashCode() : 0);
        }
    }
}
    
