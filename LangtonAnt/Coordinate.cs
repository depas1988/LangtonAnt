using System;

namespace LangtonAnt
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

        public int Diameter()
        {
            return X > Y ? X : Y;
        }
    }
}