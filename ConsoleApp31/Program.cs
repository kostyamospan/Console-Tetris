using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        private static void Main(string[] args)
        {
            /*Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("\u0023");
            Console.CursorVisible = false;
            ConsoleContainer container = new ConsoleContainer(10, 9);
            container.SetRenderFrame(container.GenerateEmptyFrame());

            container.StartRender();

            do
            {
                container.SetRenderFrame(container.RenderedFrame.RandomizeFrame());
            } while (true);*/

            // Console.ReadKey();

            //ConsoleContainer.ConsoleWindowRefreshEventProvider prov = ConsoleContainer.ConsoleWindowRefreshEventProvider.GetInstance();
            //prov.RefreshEvent += (s, a) => Console.WriteLine("Frame");

            /*ConsoleContainer c = new ConsoleContainer(10, 20);

            c.RenderedFrame.CombineWith(4,3 , new[,] { { new Pixel('#'), new Pixel('#'), new Pixel('#') }, { new Pixel(' '), new Pixel('#'), new Pixel(' ') } });
            c.RenderFrame();*/

            /*for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Figure.RandomFigure().ToString());
            }*/

            Game game = new TetrisGame();
            game.StartGame();
            game.RefreshTask.Wait();

            //Console.ReadKey();
        }
    }
}