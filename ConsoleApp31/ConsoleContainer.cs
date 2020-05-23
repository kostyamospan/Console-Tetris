using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class ConsoleContainer
    {

        public Frame RenderedFrame { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Position Position { get => _position; private set => _position = value; }

        private Position _position;

        public ConsoleContainer(int width, int heigth, Position position = null)
        {
            Position = position ?? new Position(0, 0);

            Width = width;
            Height = heigth;

            RenderedFrame = GenerateEmptyFrame();
        }

        public void SetRenderFrame(Frame frame)
        {
            RenderedFrame = frame;
        }

        public Frame GenerateEmptyFrame()
        {
            Pixel[,] pixels =  new Pixel[Height,Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    pixels[i, j] = new Pixel(ConsoleColor.Green);
                }
            }

            return new Frame(pixels);
        }

        public class ConsoleRenderer
        {
            private Frame lastFrame;

            public void RenderContainer(ConsoleContainer container)
            {
                int containerPosX = container.Position.X;
                int containerPosY = container.Position.Y;

                Pixel[,] mas = container.RenderedFrame.Pixels;

                for (int i = 0; i < container.Height; i++)
                {
                    for (int j = 0; j < container.Width; j++)
                    {
                        if (lastFrame != null)
                        {
                            if (mas[i, j].Equals(lastFrame.Pixels[i, j]))
                                continue;

                        }

                        Console.SetCursorPosition(j + containerPosX, i + containerPosY);
                        mas[i, j].WriteToConsole();
                    }
                }

                lastFrame = container.RenderedFrame;
            }
        }

        private class ConsoleWindowRefreshEventProvider
        {
            private static ConsoleWindowRefreshEventProvider _instance;

            public event EventHandler RefreshEvent;
            public Task UsedTask { get; private set; }

            public const int FRAMES_PER_SECOND = 10;

            private ConsoleWindowRefreshEventProvider()
            {
                Task.Factory.StartNew(() =>
                {
                    do
                    {
                        Thread.Sleep(1000 / FRAMES_PER_SECOND);
                        OnRefresh(this, new EventArgs());
                    } while (true);
                });
            }

            private void OnRefresh(object sender, EventArgs args) => RefreshEvent?.Invoke(sender, args);


            public static ConsoleWindowRefreshEventProvider GetInstance()
            {
                if (_instance == null)
                    _instance = new ConsoleWindowRefreshEventProvider();

                return _instance;
            }
        }
    }
}
