using LangtonAnt.DataModel;
using LangtonAnt.Interface;

namespace LangtonAnt.Rule
{
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
}