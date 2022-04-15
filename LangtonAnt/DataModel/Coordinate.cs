namespace LangtonAnt.DataModel
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate NextTo(Direction direction)
        {
            return direction switch
            {
                Direction.Right => new Coordinate(X + 1, Y),
                Direction.Up => new Coordinate(X, Y + 1),
                Direction.Left => new Coordinate(X - 1, Y),
                Direction.Down => new Coordinate(X, Y - 1)
            };
        }
    }
}