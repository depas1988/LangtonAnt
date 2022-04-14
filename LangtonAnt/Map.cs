using System;

namespace LangtonAnt
{
    public class Map
    {
        private Cell[,] _cells;
        public int Size { get; }

        public Map(int size)
        {
            Size = size;
            CreateMap();
        }

        private void CreateMap()
        {
            _cells=new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {

                for (int j = 0; j < Size; j++)
                {
                    _cells[i, j]=new Cell(Color.White,new Coordinate(i,j));
                }
            }
        }

        public Cell GetCell(Coordinate coordinate)
        {
            return _cells[coordinate.X, coordinate.Y];
        }

        public bool IsOutOfBoundaries(Ant ant)
        {
            return ant.Coordinate.Diameter() >= Size; //TODO fix check
        }
    }
}