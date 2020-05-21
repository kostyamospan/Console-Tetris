using System;

namespace Tetris
{

    class Pixel
    {
        public ConsoleColor Color { get; private set; }

        public Pixel(ConsoleColor color)
        {
            Color = color;
        }
        public Pixel()
        {
            Color = Console.ForegroundColor;
        }
    }

}