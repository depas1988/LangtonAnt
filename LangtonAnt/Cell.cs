namespace LangtonAnt
{
    public class Cell
    {
        public Color Color { get; private set; }
        public Coordinate Coordinate { get; private set; }

        public Cell(Color color, Coordinate coordinate)
        {
            Color = color;
            Coordinate = coordinate;
        }

        public void UpdateColor()
        {
            switch (Color)
            {
                case Color.Black:
                    Color=Color.White;

                    break;

                case Color.White:
                    Color = Color.Black;

                    break;
            }
        }
    }
}