using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Game
    {   
        public int Score { get; private set; }

        private ConsoleContainer _gameContainer;
        private WindowRefreshEventProvider _refreshEventProvider;
        private Queue<Figure> _figureQueue;
        private const int QUEUE_CAPACITY = 3;

        public Game()
        {
            _refreshEventProvider = WindowRefreshEventProvider.GetInstance();
            _gameContainer = new ConsoleContainer(10,20);
            _figureQueue = new Queue<Figure>(QUEUE_CAPACITY);
        }
        private void RefillQueue()
        {
            int comp = QUEUE_CAPACITY - _figureQueue.Count;
            for (int i = 0; i < comp; i++)
            {
                _figureQueue.Enqueue(Figure.RandomFigure());
            }
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            GameLogic();
            _gameContainer.RenderedFrame.RandomizeFrame();
            _gameContainer.RenderFrame();
        }
        public void GameLogic() { }
        public void StartGame()
        {
            _refreshEventProvider.RefreshEvent += OnRefresh;
        }
        public void EndGame()
        {
            _refreshEventProvider.RefreshEvent -= OnRefresh;
        }

       // public void 
        private class WindowRefreshEventProvider
        {
            private static WindowRefreshEventProvider _instance;

            public event EventHandler RefreshEvent;
            public Task UsedTask { get; private set; }

            public const int FRAMES_PER_SECOND = 10;

            private WindowRefreshEventProvider()
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


            public static WindowRefreshEventProvider GetInstance()
            {
                if (_instance == null)
                    _instance = new WindowRefreshEventProvider();

                return _instance;
            }
        }

    }
}
