using System;
using System.Collections.Generic;
using System.Text;
using LangtonAnt.DataModel;

namespace LangtonAnt.Factory
{
    public class MapFactory
    {
        private readonly Random _newRandom;

        public MapFactory()
        {
            _newRandom = new Random();
        }
        public Map Create(Coordinate bottomLeft, Coordinate topRight)
        {
            var coordinateListWithNoDefaultColor = new List<Tuple<Coordinate, Color>>();

            var sizeX = topRight.X - bottomLeft.X + 1;
            var sizeY = topRight.Y - bottomLeft.Y + 1;

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {

                    var color = (Color) _newRandom.Next(0, System.Enum.GetValues(typeof(Color)).Length);

                    if (!color.IsDefault())
                    {
                        coordinateListWithNoDefaultColor.Add(Tuple.Create(new Coordinate(i,j), color));
                    }
                    
                }
            }
            
            return new Map(bottomLeft, topRight, coordinateListWithNoDefaultColor);
        }
    }
}
