namespace LangtonAnt.DataModel
{
    public class Cell
    {
        public Color Color { get; private set; }
        public Coordinate Coordinate { get; }

        public Cell(Color color, Coordinate coordinate)
        {
            Color = color;
            Coordinate = coordinate;
        }

        public void UpdateColor(Color newColor)
        {
            Color = newColor;
        }
    }
}