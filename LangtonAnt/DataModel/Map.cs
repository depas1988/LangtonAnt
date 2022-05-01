using System;
using System.Collections.Generic;
using System.Linq;

namespace LangtonAnt.DataModel
{
    public class Map
    {
        public Cell[,] Cells { get; private set; }
        private readonly Coordinate _bottomLeft;
        private readonly Coordinate _topRight;
        private readonly List<Tuple<Coordinate, Color>> _coordinateListWithNoDefaultColor;

        public Map(Coordinate bottomLeft, Coordinate topRight, List<Tuple<Coordinate, Color>> coordinateListWithNoDefaultColor)
        {
            _bottomLeft = bottomLeft;
            _topRight = topRight;
            _coordinateListWithNoDefaultColor = coordinateListWithNoDefaultColor;

            CreateMap();
        }

        private void CreateMap()
        {
            var sizeX = _topRight.X - _bottomLeft.X+1;
            var sizeY = _topRight.Y - _bottomLeft.Y+1;

            Cells =new Cell[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    
                    var color = _coordinateListWithNoDefaultColor
                            .Where(x => x.Item1.X == i && x.Item1.Y == j)
                            .Select(x => x.Item2)
                            .DefaultIfEmpty(Enum.GetValues(typeof(Color)).OfType<Color>()
                                .FirstOrDefault(x => x.IsDefault()))
                            .FirstOrDefault()
                        ;

                    Cells[i, j]=new Cell(color,new Coordinate(i,j));
                }
            }
        }

        public Cell GetCell(Coordinate coordinate)
        {
            return Cells[coordinate.X, coordinate.Y];
        }

        public bool IsOutOfBoundaries(Ant ant)
        {
            var inX = true;
            var inY = true;

            if (ant.Coordinate.X >= _bottomLeft.X && ant.Coordinate.X <= _topRight.X)
                inX = false;

            if (ant.Coordinate.Y >= _bottomLeft.Y && ant.Coordinate.Y <= _topRight.Y)
                inY = false;

            return inX || inY;
        }
    }
}