using LangtonAnt.DataModel;
using LangtonAnt.Interface;

namespace LangtonAntTest.Utility
{
    public class DoNothingFakeRule : IRule
    {

        public bool IsApplicable(Cell cell)
        {
            return true;
        }


        public void Apply(Cell cell, Ant ant)
        {
            //null
        }
    }
}