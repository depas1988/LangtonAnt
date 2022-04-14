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
            //while(true)
            //{ 
                var cell=map.GetCell(ant.Coordinate);
            
                 _ruleList
                    .First(x => x.IsApplicable(cell))
                    .Apply(cell, ant);

                if (map.IsOutOfBoundaries(ant)) throw new GameOverException(); 
            //}
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
        bool IsApplicable(Cell cell);

        void Apply(Cell cell, Ant ant);
    }

    public class WhiteRule : IRule
    {

        public bool IsApplicable(Cell cell)
        {
            return  Color.White==cell.Color;
        }


        public void Apply(Cell cell, Ant ant)
        {
            cell.UpdateColor(Color.Black);
            ant.TurnRight();
            ant.MoveForward();
            
        }
    }

    public class BlackRule : IRule
    {
        public bool IsApplicable(Cell cell)
        {
            return Color.Black == cell.Color;
        }

        public void Apply(Cell cell, Ant ant)
        {
            cell.UpdateColor(Color.White);
            ant.TurnLeft();
            ant.MoveForward();
        }
    }

}