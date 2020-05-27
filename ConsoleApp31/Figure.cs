using System;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Tetris
{
    public class Figure
    {
        public FigureType Type { get; private set; }
        public Position Position { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public Pixel[,] Pixels { get => pixels; private set => pixels = value; }

        private Pixel[,] pixels;
        private static Random _random = new Random();
        public Figure(FigureType type, Position pos = null)
        {
            Position = pos ?? new Position(0, 0);
            Type = type;
            pixels = FigureBuilder.InitFigureBody(type, PixelTypes.Sharp);
            Width = pixels.GetLength(1);
            Height = pixels.GetLength(0);
        }

        public void RotateClockWise() => pixels = FigureBuilder.ClockWiseRotation(pixels);
        public void RotateCouterClockWise() => pixels = FigureBuilder.CounterClockWiseRotation(pixels);
        public static Figure RandomFigure() => new Figure((FigureType)_random.Next(0, Enum.GetNames(typeof(FigureType)).Length));
        public static Figure CentredFigue(int width)
        {
            var f = RandomFigure();
            f.Position.X = width / 2 - f.Width;
            return f;
        }

        public override string ToString()
        {
            StringBuilder strBlder = new StringBuilder("");

            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    strBlder.Append(pixels[i, j]?.ToString() ?? " ");
                }
                strBlder.Append("\n");
            }
            return strBlder.ToString();
        }

        private static class FigureBuilder
        {
            public static Pixel[,] ClockWiseRotation(Pixel[,] pixels)
            {
                throw new Exception();
            }
            public static Pixel[,] CounterClockWiseRotation(Pixel[,] pixels)
            {
                throw new Exception();
            }

            public static Pixel[,] InitFigureBody(FigureType type, PixelTypes pixelType)
            {
                Pixel[,] figureBody = null;

                switch (type)
                {
                    case FigureType.I_block:
                        {
                            figureBody = new Pixel[1, 4]
                            {
                                { new Pixel(pixelType), new Pixel(pixelType), new Pixel(pixelType), new Pixel(pixelType) }
                            };
                        }
                        break;

                    case FigureType.J_block:
                        {
                            figureBody = new Pixel[3, 2]
                            {
                                { null, new Pixel(pixelType) },
                                { null, new Pixel(pixelType) },
                                { new Pixel(pixelType),new Pixel(pixelType) },
                           };
                        }
                        break;

                    case FigureType.L_block:
                        {
                            figureBody = new Pixel[3, 2]
                            {
                                { new Pixel(pixelType), null },
                                { new Pixel(pixelType), null },
                                { new Pixel(pixelType), new Pixel(pixelType) },
                           };
                        }
                        break;

                    case FigureType.O_block:
                        figureBody = new Pixel[2, 2]
                           {
                                { new Pixel(pixelType), new Pixel(pixelType) },
                                { new Pixel(pixelType), new Pixel(pixelType) },
                           };
                        break;

                    case FigureType.S_block:
                        figureBody = new Pixel[2, 3]
                          {
                                { null, new Pixel(pixelType), new Pixel(pixelType) },
                                { new Pixel(pixelType), new Pixel(pixelType), null },
                          };
                        break;

                    case FigureType.T_block:
                        figureBody = new Pixel[2, 3]
                          {
                                { new Pixel(pixelType), new Pixel(pixelType), new Pixel(pixelType) },
                                { null, new Pixel(pixelType), null },
                          };
                        break;

                    case FigureType.Z_block:
                        figureBody = new Pixel[2, 3]
                          {
                                { new Pixel(pixelType), new Pixel(pixelType), null },
                                { null, new Pixel(pixelType), new Pixel(pixelType) },
                          };
                        break;
                }

                return figureBody;
            }
        }
    }
}