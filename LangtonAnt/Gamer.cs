using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LangtonAnt
{
    public class Gamer
    {
        private readonly List<IRule> _ruleList;
        public Gamer(List<IRule> ruleList)
        {
            _ruleList = ruleList;
        }

        public void Play(Ant ant, Map map)
        {
            var actualCell=map.GetCellOfCoordinate(ant.Coordinate);

            var antNewCoordinate=_ruleList
                .First(x => x.GetStartColor() == actualCell.Color)
                .MoveAnt(actualCell,ant);

            if (antNewCoordinate.Diameter() >= map.Size) throw new GameOverException();
        }

    }

    public class GameOverException : Exception
    {
        public GameOverException(): base("Game Over")
        {

        }
    }

    public interface IRule
    {
        Color GetStartColor();

        Coordinate MoveAnt(Cell actualCell, Ant ant);
    }

    public class WhiteRule : IRule
    {

        public Color GetStartColor()
        {
            return Color.White;
        }


        public Coordinate MoveAnt(Cell actualCell, Ant ant)
        {
            actualCell.UpdateColor(Color.Black);
            ant.TurnRight();
            return ant.MoveForward();
            ;
        }
    }

    public class BlackRule : IRule
    {

        public Color GetStartColor()
        {
            return Color.Black;
        }


        public Coordinate MoveAnt(Cell actualCell, Ant ant)
        {
            actualCell.UpdateColor(Color.White);
            ant.TurnLeft();
            return ant.MoveForward();
            ;
        }
    }

}