using System;
using System.ComponentModel;

namespace Tetris
{
    public class Pixel
    {
        public readonly char Symbol;
        public ConsoleColor Color { get; private set; } = ConsoleColor.Green;

        public Pixel()
        {

        }
        public Pixel(char symbol = (char)PixelTypes.Empty)
        {
            Symbol = symbol;
            Color = Console.ForegroundColor;
        }     
        public Pixel(PixelTypes type)
        {
            Color = Console.ForegroundColor;
            Symbol = (char)type;
        }
        public Pixel(ConsoleColor color)
        {
            Color = color;
            Symbol = (char)PixelTypes.Empty;
        }
        public Pixel(ConsoleColor color, PixelTypes pixelType)
        {
            Symbol = (char)pixelType;
            Color = color;
        }
        public Pixel(ConsoleColor color, char symbol)
        {
            Symbol = symbol;
            Color = color;
        }

        public void WriteToConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
            Console.ResetColor();
        }


        public override string ToString()
        {
            return Symbol.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Pixel pixel &&
                   Symbol == pixel.Symbol &&
                   Color == pixel.Color;
        }

        public override int GetHashCode()
        {
            int hashCode = 2094954129;
            hashCode = hashCode * -1521134295 + Symbol.GetHashCode();
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            return hashCode;
        }
    }

    public enum PixelTypes
    {
        Sharp = 0x0023,
        Empty = 0x0020,
    }
}