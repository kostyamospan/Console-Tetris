using System.Text;

namespace Tetris
{
    public class Figure
    {
        public FigureType Type { get; private set; }
        public Position Position { get; set; }

        private Pixel[,] pixels;

        public Figure(FigureType type)
        {
            Type = type;
            pixels = FigureBuilder.InitFigureBody(type);
        }

        public void RotateClockWise() => pixels = FigureBuilder.ClockWiseRotation(pixels);
        public void RotateCouterClockWise() => pixels = FigureBuilder.CounterClockWiseRotation(pixels);

        public override string ToString()
        {
            StringBuilder strBlder = new StringBuilder("");

            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j <pixels.GetLength(1) ; j++)
                {
                    strBlder.Append(pixels[i,j]?.ToString() ?? " ");
                }
                strBlder.Append("\n");
            }
            return strBlder.ToString();
        }
    }
}