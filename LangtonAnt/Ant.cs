using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace LangtonAnt
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
            switch (_direction)
            {
                case Direction.Right: _direction = Direction.Bottom;

                    break;

                case Direction.Up:
                    _direction = Direction.Right;

                    break;

                case Direction.Left:
                    _direction = Direction.Up;

                    break;

                case Direction.Bottom:
                    _direction = Direction.Left;

                    break;
            }
        }

        public void TurnLeft()
        {
            switch (_direction)
            {
                case Direction.Right:
                    _direction = Direction.Up;

                    break;

                case Direction.Up:
                    _direction = Direction.Left;

                    break;

                case Direction.Left:
                    _direction = Direction.Bottom;

                    break;

                case Direction.Bottom:
                    _direction = Direction.Right;

                    break;
            }
        }
        public Coordinate MoveForward()
        {
            switch (_direction)
            {
                case Direction.Right:
                    Coordinate=MoveAlongXForwardOfOneStep();

                    break;

                case Direction.Up:
                     Coordinate=MoveAlongYForwardOfOneStep();

                    break;

                case Direction.Left:
                    Coordinate=MoveAlongXBackwardOfOneStep();

                    break;

                case Direction.Bottom:
                    Coordinate=MoveAlongYBackwardOfOneStep();

                    break;
            }

            return Coordinate;
        }

        private Coordinate MoveAlongXForwardOfOneStep()
        {
            return new Coordinate(Coordinate.X + 1, Coordinate.Y);
        }

        private Coordinate MoveAlongYForwardOfOneStep()
        {
            return new Coordinate(Coordinate.X, Coordinate.Y + 1);
        }

        private Coordinate MoveAlongXBackwardOfOneStep()
        {
            return new Coordinate(Coordinate.X - 1, Coordinate.Y);
        }

        private Coordinate MoveAlongYBackwardOfOneStep()
        {
            return new Coordinate(Coordinate.X, Coordinate.Y - 1);
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
        Bottom
    }
}
