using System;
using System.Collections.Generic;
using System.Text;
using LangtonAnt.DataModel;

namespace LangtonAnt.Factory
{
    public class AntFactory
    {
        private readonly Random _newRandom;

        public AntFactory()
        {
            _newRandom = new Random();
        }
        public Ant Create(Coordinate bottomLeft, Coordinate topRight)
        {
            
            var sizeX = topRight.X - bottomLeft.X;
            var sizeY = topRight.Y - bottomLeft.Y;

            var direction = (Direction) _newRandom.Next(0, System.Enum.GetValues(typeof(Color)).Length);

            var coordinateX= _newRandom.Next(0, sizeX);

            var coordinateY = _newRandom.Next(0, sizeY);

            return new Ant(new Coordinate(coordinateX, coordinateY), direction);
        }
    }
}
