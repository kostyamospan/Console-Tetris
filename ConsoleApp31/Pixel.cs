using System;

namespace Tetris
{
    public class Pixel
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

        public void WriteToConsole()
        {
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
            Console.ResetColor();
        }

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}