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
}