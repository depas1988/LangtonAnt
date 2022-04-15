using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LangtonAnt.Interface;
using LangtonAnt.Utility;

namespace LangtonAnt.DataModel
{
    public class Gamer: IGamer
    {
        private readonly List<IRule> _ruleList;
        public Gamer(List<IRule> ruleList)
        {
            _ruleList = ruleList;
        }

        public void Play(Ant ant, Map map)
        {
            var cell=map.GetCell(ant.Coordinate);
            
                 _ruleList
                    .First(x => x.IsApplicable(cell))
                    .Apply(cell, ant);

                if (map.IsOutOfBoundaries(ant)) throw new GameOverException();
        }

    }

    public interface IGamer
    {
        void Play(Ant ant, Map map);
    }

    public interface IGame
    {
        void Run(int maxNumOfIterations);
    }

    public class Game : IGame
    {
        private readonly IGamer _gamer;
        public Ant Ant { get; }
        private Map Map { get; }
        public Game(IGamer gamer, Ant ant, Map map)
        {
            _gamer = gamer;
            Ant = ant;
            Map = map;
        }
        public void Run(int maxNumOfIterations)
        {
            var n = 0;
            while (n<=maxNumOfIterations)
            {
                _gamer.Play(Ant, Map);
                n++;
            }
        }
    }


}