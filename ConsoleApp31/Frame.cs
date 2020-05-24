using System;
using Newtonsoft.Json;
namespace Tetris
{
    public class Frame: ICloneable
    {
        public Pixel[,] Pixels { get; private set; }

        public Frame(Pixel[,] pixels)
        {
            Pixels = pixels;
        }

        public Frame RandomizeFrame()
        {
            var rnd = new Random();

            for (int i = 0; i < Pixels.GetLength(0); i++)
            {
                for (int j = 0; j < Pixels.GetLength(1); j++)
                {
                    //Pixels[i,j] = new Pixel(Console.ForegroundColor, (PixelTypes)rnd.Next(0, 2));
                    Pixels[i,j] = new Pixel(Console.ForegroundColor, rnd.Next(0, 2) == 0 ? '\u0023' : '\u0020');
                }
            }
            return new Frame(Pixels);
        }

        public void CombineWith(int left, int top, Pixel[,] pix)
        {
            for (int i = 0; i < pix.GetLength(0) && top + i < Pixels.GetLength(0)  ; i++)
            {
                for (int j = 0; j < pix.GetLength(1) && left + j < Pixels.GetLength(1) ; j++)
                {
                    Console.WriteLine(Pixels.GetLength(0));
                    Pixels[i+top,j+left] = pix[i,j] ?? Pixels[i + top, j + left];
                }
            }
        }

        public object Clone()
        {
            var res = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(this));
            return res;
        }
    }
}