using LangtonAnt.DataModel;
using LangtonAnt.Interface;

namespace LangtonAnt.Rule
{
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