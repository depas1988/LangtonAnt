namespace LangtonAnt.DataModel
{
    public class Map
    {
        public Cell[,] Cells { get; private set; }
        private readonly Coordinate _bottomLeft;
        private readonly Coordinate _topRight;
        public Map(Coordinate bottomLeft, Coordinate topRight)
        {
            _bottomLeft = bottomLeft;
            _topRight = topRight;

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
                    Cells[i, j]=new Cell(Color.White,new Coordinate(i,j));
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