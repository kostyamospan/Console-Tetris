using System;

namespace Tetris
{
    class Pixel
    {
        public const char Symbol = '#';
        public ConsoleColor Color { get; private set; }

        public Pixel(ConsoleColor color)
        {
            Color = color;
        }
        public Pixel()
        {
            Color = Console.ForegroundColor;
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}