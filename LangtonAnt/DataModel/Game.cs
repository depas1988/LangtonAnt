using LangtonAnt.Interface;
using LangtonAnt.Utility;

namespace LangtonAnt.DataModel
{
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
            if (maxNumOfIterations < 1) throw new GameOverException();

            while (maxNumOfIterations-- > 0)
                _gamer.Play(Ant, Map);
        }
    }
}