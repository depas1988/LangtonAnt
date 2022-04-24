namespace LangtonAnt.DataModel
{
    public class Ant
    {
        public Coordinate Coordinate { get; private set; }
        public Direction Direction { get; private set; }

        public Ant(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }

        public void TurnRight()
        {
            Direction = Direction switch
            {
                Direction.Right => Direction.Down,
                Direction.Up=> Direction.Right,
                Direction.Left=> Direction.Up,
                Direction.Down => Direction.Left
            };
        }

        public void TurnLeft()
        {
            Direction = Direction switch
            {
                Direction.Right => Direction.Up,
                Direction.Up => Direction.Left,
                Direction.Left => Direction.Down,
                Direction.Down => Direction.Right
            };
            
        }
        public void MoveForward()
        {
            Coordinate=Coordinate.NextTo(Direction);
        }
    }

    public enum Color
    {
        Black,
        White
    }

    public enum Direction
    {
        Right,
        Up,
        Left,
        Down
    }
}
