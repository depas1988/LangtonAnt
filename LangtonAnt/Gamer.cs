using System;
using System.Collections;

namespace LangtonAnt
{
    public class Gamer
    {

        public void Play(Ant ant, Map map)
        {

            var actualCell=map.GetCellOfCoordinate(ant.Coordinate);


            switch (actualCell.Color)
            {
                case Color.White:
                    actualCell.UpdateColor();
                    ant.TurnRight();
                
                    break;

                case Color.Black:
                    actualCell.UpdateColor();
                    ant.TurnLeft();
                    
                    break;

            }

            var newCoordinate = ant.MoveForward();

            if (newCoordinate.Diameter() >= map.Size) throw new GameOverException();
        }

    }

    public class GameOverException : Exception
    {
        public GameOverException(): base("Game Over")
        {

        }
    }

}