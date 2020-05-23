using System;

namespace Tetris
{
    class Program
    {
        private static void Main(string[] args)
        {

            ConsoleContainer container = new ConsoleContainer(10,9);

            ConsoleContainer.ConsoleRenderer renderer = new ConsoleContainer.ConsoleRenderer();

            renderer.RenderContainer(container);


            Console.ReadKey();
        }
    }
}