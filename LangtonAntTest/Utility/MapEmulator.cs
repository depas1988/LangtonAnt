using System;
using System.Collections.Generic;
using System.Linq;
using LangtonAnt.DataModel;

namespace LangtonAntTest.Utility
{
    //public class MapEqualityComparer : IEqualityComparer<Map>
    //{
    //    private readonly CellEqualityComparer _cellEqualityComparer;

    //    public MapEqualityComparer(CellEqualityComparer cellEqualityComparer)
    //    {
    //        _cellEqualityComparer = cellEqualityComparer;
    //    }

    //    public bool Equals(Map x, Map y)
    //    {
    //        if (ReferenceEquals(x, y)) return true;
    //        if (ReferenceEquals(x, null)) return false;
    //        if (ReferenceEquals(y, null)) return false;
    //        if (x.GetType() != y.GetType()) return false;

    //        //flat a multi-dimension array
    //        return x.Cells.Cast<Cell>().SequenceEqual(y.Cells.Cast<Cell>(), _cellEqualityComparer);
    //    }

    //    public int GetHashCode(Map obj)
    //    {
    //        return (obj.Cells != null ? obj.Cells.GetHashCode() : 0);
    //    }
    //}


    //public class MapFactoryHelper
    //{
    //    public Map GetMap()
    //    {
    //        return new Map(new Coordinate(0,0), new Coordinate(40,40));
    //    }
    //}

    public class MapEmulator : IComparable<Map>
    {
        public Cell[,] Cells { get; private set; }
        private readonly Coordinate _bottomLeft;
        private readonly Coordinate _topRight;
        private readonly CellEqualityComparer _cellEqualityComparer;
        public MapEmulator(Coordinate bottomLeft, Coordinate topRight, CellEqualityComparer cellEqualityComparer)
        {
            _bottomLeft = bottomLeft;
            _topRight = topRight;
            _cellEqualityComparer = cellEqualityComparer;

            CreateMap();
        }

        private void CreateMap()
        {
            var sizeX = _topRight.X - _bottomLeft.X + 1;
            var sizeY = _topRight.Y - _bottomLeft.Y + 1;

            Cells = new Cell[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {

                for (int j = 0; j < sizeY; j++)
                {
                    Cells[i, j] = new Cell(Color.White, new Coordinate(i, j));
                }
            }
        }

        public void UpdateCell(Coordinate coordinate, Action<Cell> action)
        {
            var xc = coordinate.X;
            var yc = coordinate.Y;

            var cellToUpdate = Cells
                .Cast<Cell>()
                .First(cell => cell.Coordinate.X == xc && cell.Coordinate.Y == yc);

            action.Invoke(cellToUpdate);
        }


        public int CompareTo(Map other)
        {
            if (Cells.Cast<Cell>().SequenceEqual(other.Cells.Cast<Cell>(), _cellEqualityComparer))
                return 0;
            return -1;
        }
    }
}