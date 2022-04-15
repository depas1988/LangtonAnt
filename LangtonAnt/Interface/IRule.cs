using LangtonAnt.DataModel;

namespace LangtonAnt.Interface
{
    public interface IRule
    {
        bool IsApplicable(Cell cell);

        void Apply(Cell cell, Ant ant);
    }
}