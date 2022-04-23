using LangtonAnt.DataModel;

namespace LangtonAnt.Interface
{
    public interface IGame
    {
        void Run(int maxNumOfIterations, Ant ant, Map map);
    }
}