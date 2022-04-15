namespace LangtonAnt.DataModel
{
    public class Ant
    {
        public Coordinate Coordinate { get; private set; }
        private Direction _direction;

        public Ant(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            _direction = direction;
        }

        public void TurnRight()
        {
            _direction = _direction switch
            {
                Direction.Right => Direction.Down,
                Direction.Up=> Direction.Right,
                Direction.Left=> Direction.Up,
                Direction.Down => Direction.Left
            };
        }

        public void TurnLeft()
        {
            _direction = _direction switch
            {
                Direction.Right => Direction.Up,
                Direction.Up => Direction.Left,
                Direction.Left => Direction.Down,
                Direction.Down => Direction.Right
            };
            
        }
        public void MoveForward()
        {
            Coordinate=Coordinate.NextTo(_direction);
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
