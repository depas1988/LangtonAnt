using System.Collections.Generic;
using System.Linq;
using LangtonAnt.DataModel;

namespace LangtonAntTest.Utility
{
    public class MapEqualityComparer : IEqualityComparer<Map>
    {
        private readonly CellEqualityComparer _cellEqualityComparer;

        public MapEqualityComparer(CellEqualityComparer cellEqualityComparer)
        {
            _cellEqualityComparer = cellEqualityComparer;
        }

        public bool Equals(Map x, Map y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;

            //flat a multi-dimension array
            return x.Cells.Cast<Cell>().SequenceEqual(y.Cells.Cast<Cell>(), _cellEqualityComparer);
        }

        public int GetHashCode(Map obj)
        {
            return (obj.Cells != null ? obj.Cells.GetHashCode() : 0);
        }
    }
}