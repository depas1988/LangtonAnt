using LangtonAnt.Interface;
using LangtonAnt.Utility;

namespace LangtonAnt.DataModel
{
    public class Game : IGame
    {
        private readonly IGamer _gamer;
        public Game(IGamer gamer)
        {
            _gamer = gamer;
        }
        public void Run(int maxNumOfIterations, Ant ant, Map map)
        {
            if (maxNumOfIterations < 1) throw new GameOverException();

            while (maxNumOfIterations-- > 0)
                _gamer.Play(ant, map);
        }
    }
}