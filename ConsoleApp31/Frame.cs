namespace Tetris
{
    public class Frame
    {
        public Pixel[,] Pixels { get; private set; }

        public Frame(Pixel[,] pixels)
        {
            Pixels = pixels;
        }
    }
}