using LangtonAnt.DataModel;
using LangtonAnt.Interface;

namespace LangtonAntTest.Utility
{
    public class MoveOnlyForwardFakeRule : IRule
    {

        public bool IsApplicable(Cell cell)
        {
            return true;
        }


        public void Apply(Cell cell, Ant ant)
        {
            ant.MoveForward();
        }
    }
}